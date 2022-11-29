using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unimanagement_api.Entitites
{
    public class Attendance
    {
        public int Id { get; set; }
        public string SubjectId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string date { get; set; }
        public string time { get; set; }

    }
}
