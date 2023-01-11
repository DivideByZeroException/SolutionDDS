using System;

namespace TestSwaggerApi
{
    public class DDSDataRow
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

        public string Type { get => type; set => type = value; }
        public int Summ { get => summ; set => summ = value; }
        public string Fond { get => fond; set => fond = value; }
        public string What { get => what; set => what = value; }
        public string Person { get => person; set => person = value; }
        public string Month { get => month; set => month = value; }
        public string Month_number { get => month_number; set => month_number = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Comm { get => comm; set => comm = value; }
    }
}