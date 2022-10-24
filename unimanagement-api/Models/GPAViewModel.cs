using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unimanagement_api.Entitites;

namespace unimanagement_api.Models
{
    public class GPAViewModel
    {
        public float Score { get; set; }
        public List<GPASubject> GPASubjects { get; set; }
    }
}
