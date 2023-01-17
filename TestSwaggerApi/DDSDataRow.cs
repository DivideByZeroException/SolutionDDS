using System;

namespace TestSwaggerApi
{
    public class DDSDataRow
    {
        string type;
        int sum;
        string fond;
        string what;
        string person;
        string month;
        string numberMonth;
        DateTime date;
        string comm;

        public string Type { get => type; set => type = value; }
        public int Sum { get => sum; set => sum = value; }
        public string Fond { get => fond; set => fond = value; }
        public string What { get =>  what; set => what = value; }
        public string Person { get => person; set => person = value; }
        public string Month { get => month; set => month = value; }
        public string NumberMonth { get => numberMonth; set => numberMonth = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Comm { get => comm; set => comm = value; }
    }
}