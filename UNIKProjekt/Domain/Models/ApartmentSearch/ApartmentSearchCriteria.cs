using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.ApartmentSearch
{
    public class ApartmentSearchCriteria
    {
        public Dictionary<string, bool> Type { get; set; }
        public Dictionary<Dictionary<int, string>, bool> Area { get; set; }
        public Dictionary<string, bool> Other { get; set; }
    }
}
