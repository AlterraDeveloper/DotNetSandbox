using System;
using System.Data.SqlClient;

namespace DotnetSandbox.Common
{
    public class ExecuteManger
    {
        public ExecuteResult Execute(IManager manager)
        {
            try
            {
                manager.Execute();
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                return new ExecuteResult
                {
                    IsSuccess = false
                };
            }
            return new ExecuteResult();
        }
    }
}