using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unimanagement_api.Entitites
{
    public class Attendance
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
    }
}
