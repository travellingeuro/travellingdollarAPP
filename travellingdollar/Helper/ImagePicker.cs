using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xamarin.Forms;

namespace travellingdollar.Helper
{
	public class ImagePicker
	{
		public ImageSource Image { get; set; }
        public ImageSource Imagepicker(int value)
		{
			switch (value)
			{
                case 1:
					Image= ImageSource.FromResource("travellingdollar.Images.one.gif");
					break;
				case 2:
					Image = ImageSource.FromResource("travellingdollar.Images.two.gif");
					break;
				case 5:
					Image = ImageSource.FromResource("travellingdollar.Images.five.gif");
					break;
				case 10:
					Image = ImageSource.FromResource("travellingdollar.Images.ten.gif");
					break;
				case 20:
					Image = ImageSource.FromResource("travellingdollar.Images.twenty.gif");
					break;
				case 50:
					Image = ImageSource.FromResource("travellingdollar.Images.fifty.gif");
					break;
				case 100:
					Image = ImageSource.FromResource("travellingdollar.Images.hundred.gif");
					break;
				default:
					Image = ImageSource.FromResource("travellingdollar.Images.specimen.gif");
					break;
			}
			return Image;
		}
	}
}
