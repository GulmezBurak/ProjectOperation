using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOperation
{
    internal class Operation
    {
        public Operation()
        {
           TimeSpan TotalTime = (End - Start) /3600;

         //  TimeSpan TotalTime = TotalTime / 1000;
        }
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TotalTime { get; set; }
        public string Status { get; set; }
        public string StopReason { get; set; }

    }
}
