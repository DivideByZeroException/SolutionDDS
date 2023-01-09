using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestSwaggerApi
{
    public class WeatherForecast
    {
        List<string> like = new List<string>();
        string fond = "Фонд основателя";
        int summ = 0;
        string type = "доход";
        string what = "Налоги";
        string person = "DS";
        DateTime date = DateTime.Now;
        string month = "январь";
        string number_month = "1";
        string comm;
        string sub;
        IList<IList<object>> val = RunAsync();

        List<string> lines = new List<string>();

        public IList<IList<object>> Val { get => val; set => val = value; }

        static IList<IList<object>> RunAsync()
        {

            // Create the service.
            string[] Scopes = new string[] { SheetsService.Scope.Spreadsheets, DriveService.Scope.Drive };
            string sheet = "ДДС";
            string secondsheet = "Источники (списки)";
            string id = "1r3UZ4Hh3d2FepCK3N2pBccXVh2YCek0bSYb8pR82G_w";

            GoogleCredential credential;
            using (var stream = new FileStream("cr1.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            // Create the service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "ItsTableProject",
            });
            var range = $"{secondsheet}!A:J";
            var req = service.Spreadsheets.Values.Get(id, range);
            var res = req.Execute();
            var val = res.Values;
            return val;





        }
    }

    
}
