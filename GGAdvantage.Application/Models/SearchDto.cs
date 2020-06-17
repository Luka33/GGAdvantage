using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGAdvantage.Application.Models
{
    public class SearchDto
    {
        public int Paging { get; set; }
        public string name { get; set; }

        public string filterName { get; set; }
        public string filterValue { get; set; }
    }
}
