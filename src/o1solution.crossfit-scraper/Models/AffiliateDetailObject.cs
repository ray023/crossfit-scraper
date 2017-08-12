namespace o1solution.crossfitscraper.Models
{
    internal class AffiliateDetailObject
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool CfKids { get; set; }
        public string Phone { get; set; }
        public AffiliateCourse[] Courses { get; set; }
    }
}
