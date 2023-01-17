using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestSwaggerApi
{
    public class WorkWithExcel
    {
        public IList<IList<object>> GetResourse()
        {
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
        public string Save(string type, int sum, string fond, string what, string person, string month, string numberMonth, DateTime date, string comm)
        {
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

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "ItsTableProject",
            });

            var range1 = $"{sheet}!A:A";
            var req1 = service.Spreadsheets.Values.Get(id, range1);
            var res1 = req1.Execute();
            int row = res1.Values.Count + 1;
            var range = $"{sheet}!A{row}:I{row}";
            Console.WriteLine(range);
            var setValue = new List<List<object>> { new List<object> { type, sum, what, comm, person, month, date.ToString("dd.MM.yyyy"), fond, numberMonth } };
            var req = service.Spreadsheets.Values.Update(new Google.Apis.Sheets.v4.Data.ValueRange { Values = new List<IList<object>>(setValue) }, "1r3UZ4Hh3d2FepCK3N2pBccXVh2YCek0bSYb8pR82G_w", range);
            req.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var res = req.Execute();

            return "OK";
        }
    }
}

