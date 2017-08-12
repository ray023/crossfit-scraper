using o1solution.crossfitscraper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.Models
{
    public class Event
    {
        public string LatLng { get; set; }
        public string AffiliateName { get; set; }
        public string Location { get; set; }
        public string LocationStartDate { get; set; }
        public string LocationEndDate { get; set; }
        public string Aid { get; set; }
        public EventList[] EventList { get; set; }
        public string Latitude
        {
            get
            {
                const int LAT_INDEX = 0;
                if (!this.LatLng.Contains(","))
                    return string.Empty;

                return this.LatLng.Split(',')[LAT_INDEX];
            }
        }
        public string Longitude
        {
            get
            {
                const int LONG_INDEX = 1;
                if (!this.LatLng.Contains(","))
                    return string.Empty;

                return this.LatLng.Split(',')[LONG_INDEX];
            }
        }

        public string GetMySqlInsertLine()
        {
            StringBuilder sb = new StringBuilder();
            EventList
                .ToList()
                .ForEach(x => sb
                                .Append("INSERT INTO `events` VALUES (")
                                .Append("NULL")
                                .Append($",{x.Id?.WrapString()}")
                                .Append($",{x.Url?.WrapString()}")
                                .Append($",{AffiliateName?.WrapString()}")
                                .Append($",{Location?.WrapString()}")
                                .Append($",{x.Date?.WrapString()}")
                                .Append($",{x.Name?.WrapString().Replace("SPEAR&#153;",string.Empty)}")
                                .Append($",{Latitude}")
                                .Append($",{Longitude}")
                                .Append($",{x.StartDate}")
                                .Append(");"));
            return sb.ToString();
        }
    }
}
