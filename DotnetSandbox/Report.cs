﻿using System.Collections.Generic;

namespace DotnetSandbox
{
    public class Report
    {
        public Report()
        {
            
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
                new ReportRow("dsbhvbsdjk"),
                new ReportRow("dsbhvbsdjk"),
                new ReportRow("dsbhvbsdjk"),
                new ReportRow("dsbhvbsdjk"),
                new ReportRow("dsbhvbsdjk"),
                new ReportRow("dsbhvbsdjk"),
                new ReportRow("dsbhvbsdjk"),
                new ReportRow("dsbhvbsdjk"),
                new ReportRow("dsbhvbsdjk"),
                new ReportRow("dsbhvbsdjk"),
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