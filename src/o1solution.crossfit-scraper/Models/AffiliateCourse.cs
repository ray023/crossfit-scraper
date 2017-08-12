namespace o1solution.crossfitscraper.Models
{
    public class AffiliateCourse
    {
        public AffiliateCourse()
        {
            CourseName = string.Empty;
            Dates = string.Empty;
            Url = string.Empty;
        }
        public string CourseName { get; set; }
        public string Id { get; set; }
        public bool Is_waitlisted { get; set; }
        public string Dates { get; set; }
        public string Url { get; set; }
    }
}