using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unimanagement_api.Entitites
{
    public class GPASubject
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Level { get; set; }
        public int StudentId { get; set; }
    }
}
