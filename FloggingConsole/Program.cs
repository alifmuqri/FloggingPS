﻿using Flogging.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloggingConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fd = GetFlogDetail("starting application", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker("FloggerConsole_Execution", "", fd.UserName, fd.Location, fd.Product, fd.Layer);

            try
            {
                var ex = new Exception("Something bad has happened!");
                ex.Data.Add("input param", "nothing to see here");
                throw ex;
            }
            catch (Exception ex)
            {
                fd = GetFlogDetail("", ex);
                Flogger.WriteError(fd);
            }

            fd = GetFlogDetail("used flogging console", null);
            Flogger.WriteUsage(fd);

            fd = GetFlogDetail("stopping app", null);
            Flogger.WriteDiagnostic(fd);

            tracker.Stop();
        }

        private static FlogDetail GetFlogDetail(string message, Exception ex)
        {
            return new FlogDetail
            {
                Product = "Flogger",
                Location = "FloggerConsole",
                Layer = "Job",
                UserName = Environment.UserName,
                HostName = Environment.MachineName,
                Message = message,
                Exception = ex
            };
        }
    }
}
