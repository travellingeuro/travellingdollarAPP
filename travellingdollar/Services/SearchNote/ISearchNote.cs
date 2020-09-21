using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace travellingdollar.Services.SearchNote
{
    public interface ISearchNote
    {
        Task<List<Models.Uploads>> GetSearchAsync(string serialnumber);
        Task<List<Models.Uploads>> GetAllAsync();
    }
}
