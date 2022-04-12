using System;
using System.Collections.Generic;

namespace DotnetSandbox
{
    public class Report
    {

        private int _pageCount;
        private int _itemsPerPage;
        private DateTime _reportDate;
        
        public Report(List<string> parameters)
        {
            SetParameters(parameters);
            SetTitle();
        }

        private void SetTitle()
        {
            Console.WriteLine(_reportDate);
        }

        private void SetParameters(List<string> parameters)
        {
            _pageCount = int.Parse(parameters[0]);
            _itemsPerPage = int.Parse(parameters[0]);
        }

        public void Build()
        {
            var column1 = new ReportColumn("1");
            var column2 = new ReportColumn("2");
            var column3 = new ReportColumn("3");
            var column4 = new ReportColumn("4");
            var column5 = new ReportColumn("5");
            var column6 = new ReportColumn("6");
        }

        public void Fill()
        {
            var rows = new List<ReportRow>
            {
                new ReportRow("Row #1"),
                new ReportRow("Row #2"),
                new ReportRow("Row #3"),
                new ReportRow("Row #4"),
            };
        }
    }

    public class ReportColumn
    {
        public ReportColumn(string columnName)
        {
            
        }
    }

    public class ReportRow
    {
        public ReportRow(string content){}
    }
}