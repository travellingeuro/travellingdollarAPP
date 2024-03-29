﻿using Microsoft.AppCenter;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.SfMaps.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using travellingdollar.Controls;
using travellingdollar.Exceptions;
using travellingdollar.Helper;
using travellingdollar.Models;
using travellingdollar.Services.Dialogs;
using travellingdollar.Services.SearchNote;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace travellingdollar.ViewModels
{
    [Preserve(AllMembers = true)]
    public class StatsViewModel : BindableBase, INavigationAware
    {
        //Services
        public IDialogService dialogService { get; private set; }
        public ISearchNote searchNote { get; private set; }

        //Properties
        private List<Uploads> uploads;
        public List<Uploads> Uploads
        {
            get { return uploads; }
            set { SetProperty(ref uploads, value); }
        }

        private bool isbusy;
        public bool IsBusy
        {
            get { return isbusy; }
            set { SetProperty(ref isbusy, value); }
        }

        private object notevalue;
        public object NoteValue
        {
            get => notevalue;
            set
            {
                notevalue = value;
                SetMarkers();
                RaisePropertyChanged();
            }
        }

        private int totalnotes;
        public int TotalNotes
        {
            get { return totalnotes; }
            set { SetProperty(ref totalnotes, value); }
        }

        private ObservableCollection<MapMarker> viewmarkers = new ObservableCollection<MapMarker>();

        public ObservableCollection<MapMarker> ViewMarkers
        {
            get { return viewmarkers; }
            set { SetProperty(ref viewmarkers, value); }
        }

        //ctr
        public StatsViewModel(IDialogService dialogService, ISearchNote searchNote)
        {
            this.dialogService = dialogService;
            this.searchNote = searchNote;
            IsBusy = true;
        }

        private async Task<List<Uploads>> GetUploads()
        {
            _ = new List<Uploads>();
            try
            {
                IsBusy = true;
                List<Uploads> alluploads = await searchNote.GetAllAsync();
                return alluploads;
            }

            catch (HttpRequestException httpEx)
            {

                Debug.WriteLine($"[Booking Where Step] Error retrieving data: {httpEx}");

                if (!string.IsNullOrEmpty(httpEx.Message))
                {
                    await dialogService.ShowAlertAsync(
                        string.Format(Resources.HttpRequestExceptionMessage, httpEx.Message),
                        Resources.HttpRequestExceptionTitle,
                        Resources.DialogOk);
                }

                return new List<Uploads>();

            }
            catch (ConnectivityException cex)
            {

                Debug.WriteLine($"[Booking Where Step] Connectivity Error: {cex}");
                await dialogService.ShowAlertAsync("There is no Internet conection, try again later.", "Error", "Ok");
                return new List<Uploads>();

            }
            catch (Exception ex)
            {

                await dialogService.ShowAlertAsync(ex.Message, Resources.ErrorTitle, Resources.DialogOk);
                return new List<Uploads>();

            }
            finally
            {
                // IsBusy = false;
            }

        }

        private void SetMarkers()
        {
            if (NoteValue != null && Uploads != null)
            {
                var imagepicker = new ImagePicker();
                int.TryParse((string)NoteValue, out int value);
                //selects Uploads with a NoteValue           
                var selectedvaluenotes = Uploads.Where(v => v.Value == value);
                TotalNotes = selectedvaluenotes.Select(s => s.SerialNumber).Distinct().Count();
                //empty ViewMarkers
                if (ViewMarkers.Any())
                {
                    ViewMarkers.Clear();
                }

                //transforms to Marker list
                foreach (var upload in selectedvaluenotes)
                {
                    var marker = new CustomMarker
                    {
                        Latitude = upload.Latitude.ToString(),
                        Longitude = upload.Longitude.ToString(),
                        Label = upload.Comments,
                        Address = upload.Address,
                        Date = upload.UploadDate,
                        Image = imagepicker.Imagepicker(upload.Value),
                        Name = upload.Name,
                        Serial = upload.SerialNumber
                    };
                    ViewMarkers.Add(marker);
                }
            }
        }

        private void SetInitialMarkers()
        {
            if (Uploads != null)
            {
                var imagepicker = new ImagePicker();

                //show all notes markers in the map
                //empty ViewMarkers
                if (ViewMarkers.Any())
                {
                    ViewMarkers.Clear();
                }
                foreach (var upload in Uploads)
                {
                    var marker = new CustomMarker
                    {
                        Latitude = upload.Latitude.ToString(),
                        Longitude = upload.Longitude.ToString(),
                        Label = upload.Comments,
                        Address = upload.Address,
                        Date = upload.UploadDate,
                        Image = imagepicker.Imagepicker(upload.Value),
                        Name = upload.Name,
                        Serial = upload.SerialNumber
                    };
                    ViewMarkers.Add(marker);
                }
            }
            IsBusy = false;
        }


        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Uploads = Task.Run(GetUploads).Result;
            SetInitialMarkers();
            TotalNotes = Uploads.Select(s => s.SerialNumber).Distinct().Count();
            IsBusy = false;
        }
    }
}
