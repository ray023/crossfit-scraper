using o1solution.crossfitscraper.Extensions;
using System;
using System.Linq;
using System.Text;

namespace o1solution.crossfitscraper.Models
{
    public class Affiliate
    {
        public Affiliate()
        {
            Name = string.Empty;
            Website = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Zip = string.Empty;
            Phone = string.Empty;
        }
        #region pulled from main call GetAllAffiliates
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; }
        public int AffiliteId { get; set; }
        public int SecretField { get; set; }
        #endregion
        #region Details -- Loaded later with async call
        public string Website { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool CfKids { get; set; }
        public string Phone { get; set; }
        public AffiliateCourse[] Courses { get; set; }
        #endregion
        public string GetMySqlInsertLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO `affiliates` (")
                        .Append("crossfit_affiliate_id,affil_name,url,")
                        .Append("address1,city_state_zip,phone,")
                        .Append("latitude,longitude,cf_kids) ")
                        .Append("VALUES (")
                        .Append($"{AffiliteId}")
                        .Append($",{Name.WrapString()}")
                        .Append($",{Website.WrapString()}")
                        .Append($",{Address.WrapString()}")
                        .Append(",")
                        .Append($"{City}, {State}  {Zip}".WrapString())
                        .Append($",{Phone.WrapString()}")
                        .Append($",{Latitude}")
                        .Append($",{Longitude}")
                        .Append($",{CfKids}")
                        .Append(");");

            Courses?
                .ToList()
                .ForEach(x => sb
                                .Append("INSERT INTO `affiliate_courses` VALUES (")
                                .Append("NULL")
                                .Append($",{AffiliteId}") //id_from_cross_fit
                                .Append($",{x.CourseName.WrapString()}") //course_name
                                .Append($",{x.Is_waitlisted}") //is_waitlisted
                                .Append($",{x.Dates.WrapString()}") //dates
                                .Append($",{x.Url.WrapString()}") //url
                                .Append(");"));
            return sb.ToString();
        }
    }
}
