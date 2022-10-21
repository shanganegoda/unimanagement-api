using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unimanagement_api.Entitites
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
    }
}
