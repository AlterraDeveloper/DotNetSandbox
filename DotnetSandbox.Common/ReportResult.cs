using System.Collections.Generic;
using System.Linq;

namespace DotnetSandbox.Common
{
    public class ReportResult : ExecuteResult
    {
        public List<string> Files { get; set; } = new List<string>();

        public List<string> Errors { get; set; } = new List<string>();
        
        public static ReportResult operator +(ReportResult r1, ReportResult r2)
        {
            if (r1 == null) return r2;
            if (r2 == null) return r1;
            
            return new ReportResult
            {
                IsSuccess = r1.IsSuccess && r2.IsSuccess,
                Errors = r1.Errors.Concat(r2.Errors).ToList(),
                Files = r1.Files.Concat(r2.Files).ToList()
            };
        }
    }
}