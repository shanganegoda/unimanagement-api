using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unimanagement_api.Entitites
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public string Description { get; set; }
    }
}
