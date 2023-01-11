using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestSwaggerApi.Client;
using System.Text.Json;
using System.Text;

namespace TestSwaggerApi.WEB.Pages
{
   
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GetResourceClient GetResourceClient;
        private readonly SaveDataClient SaveDataClient;
        public ICollection<ICollection<object>> Resourse;
      
        public string Title { get; private set; }

        private string SaveResult;

        public IndexModel(
            ILogger<IndexModel> logger,
            GetResourceClient getResource, SaveDataClient saveDataClient)
        {
            _logger = logger;
            this.SaveDataClient = saveDataClient;
            this.GetResourceClient = getResource;
            
            
        }

       

        [HttpGet]
        public async Task OnGet()
        {
            
            this.Resourse = await this.GetResourceClient.GetAsync();
        }
        [HttpPost]
        public async Task OnPost(string type,int summ, string fond,string what,
            string person,string month,string month_number,DateTime date,string comm)
        {
            await this.SaveDataClient.PostAsync(type,  summ,  fond,  what,
             person,  month,  month_number,  date,  comm);
        }

    }
}
