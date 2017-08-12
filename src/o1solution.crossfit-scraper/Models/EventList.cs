using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.Models
{
    public class EventList
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool Is_WaitListed { get; set; }
        public string Date { get; set; }
        public string Url { get; set; }
        public string StartDate
        {
            get
            {
                const int YEAR_INDEX = 1;
                const char YEAR_SPLIT_CHAR = ',';
                const int MONTH_INDEX = 0;
                const int DAY_INDEX = 1;
                const char MONTH_DAY_SPLIT_CHAR = ' ';
                const char DAY_SPLIT_CHAR = '-';
                const int FIRST_DAY_INDEX = 0;

                var year = Date.Split(YEAR_SPLIT_CHAR)[YEAR_INDEX].Trim();
                var monthDayArray = Date.Split(MONTH_DAY_SPLIT_CHAR);

                var month = GetMonthAsNumber(monthDayArray[MONTH_INDEX]);
                var day = monthDayArray[DAY_INDEX].Split(DAY_SPLIT_CHAR)[FIRST_DAY_INDEX];

                return $"'{year}-{month}-{day}'";
            }
        }

        /// <summary>
        /// Yes, I know there are better ways.  This is how I want to do it.
        /// </summary>
        /// <param name="monthText"></param>
        /// <returns></returns>
        private string GetMonthAsNumber(string monthText)
        {
            string monthNum = "0";
            switch (monthText)
            {
                case "January":
                    monthNum = "1";
                    break;
                case "February":
                    monthNum = "2";
                    break;
                case "March":
                    monthNum = "3";
                    break;
                case "April":
                    monthNum = "4";
                    break;
                case "May":
                    monthNum = "5";
                    break;
                case "June":
                    monthNum = "6";
                    break;
                case "July":
                    monthNum = "7";
                    break;
                case "August":
                    monthNum = "8";
                    break;
                case "September":
                    monthNum = "9";
                    break;
                case "October":
                    monthNum = "10";
                    break;
                case "November":
                    monthNum = "11";
                    break;
                case "December":
                    monthNum = "12";
                    break;
            }
            return monthNum;
        }
    }
}
