using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOperation
{
    internal class StandardStop
    {
        public StandardStop()
        {
            TimeSpan TotalTime = (End - Start) / 3600;

        }
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StopReason { get; set; }
        public int TotalTime { get; set; }

    }
}
