using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestSwaggerApi
{
    public class SaveData
    {
        string type;
        int summ; 
        string fond; 
        string what; 
        string person; 
        string month;
        string month_number; 
        DateTime date;
        string comm;
        

        public SaveData(string type, int summ, string fond, string what, string person, string month, string month_number, DateTime date, string comm)
        {
            
            this.type = type;
            this.summ = summ;
            this.fond = fond;
            this.what = what;
            this.person = person;
            this.month = month;
            this.month_number = month_number;
            this.date = date;
            this.comm = comm;
            string res = ok(type, summ, fond,  what,  person,  month,  month_number,  date,  comm);
        }

        public static string ok(string type, int summ, string fond, string what, string person, string month, string month_number, DateTime date, string comm)
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

            var range1 = $"{sheet}!A:A";
            var req1 = service.Spreadsheets.Values.Get(id, range1);
            var res1 = req1.Execute();
            int row = res1.Values.Count + 1;
            var range = $"{sheet}!A{row}:I{row}";
            Console.WriteLine(range);
            var setValue = new List<List<object>> { new List<object> { type,summ, what, comm, person, month, date.ToString("dd.MM.yyyy"), fond, month_number } };
            var req = service.Spreadsheets.Values.Update(

                new Google.Apis.Sheets.v4.Data.ValueRange { Values = new List<IList<object>>(setValue) }, "1r3UZ4Hh3d2FepCK3N2pBccXVh2YCek0bSYb8pR82G_w", range);
            req.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var res = req.Execute();
            return "OK";
            
        }




    }

    
}
