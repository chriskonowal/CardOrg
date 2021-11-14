using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    public class SortViewModel
    {
        public SortViewModel(int sortId, string name)
        {
            SortId = sortId;
            Name = name;
        }

        public string Name { get; set; }

        public int SortId { get; set; }
    }
}
