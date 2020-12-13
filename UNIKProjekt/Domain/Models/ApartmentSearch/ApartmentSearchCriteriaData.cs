using System.Collections.Generic;

namespace Domain.Models.ApartmentSearch
{
    public static class ApartmentSearchCriteriaData
    {
        public static List<string> Type = new List<string>() {
            "Villa",
            "Rækkehus",
            "Lejlighed",
            "Værelse",
            "Ungdomsbolig"
        };
        public static Dictionary<int, string> Area = new Dictionary<int, string>() {
            { 6000, "Kolding" },
            { 7000, "Fredericia" },
            { 7100, "Vejle" },
        };

        public static List<string> Other = new List<string>() {
            "Husdyr tilladt",
            "Delevenlig",
            "Møbleret",
        };
    }
}
