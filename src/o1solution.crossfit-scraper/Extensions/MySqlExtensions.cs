using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1solution.crossfitscraper.Extensions
{
    public static class MySqlExtensions
    {
        public static string WrapString(this string insertValue)
        {
            return $"'{insertValue.Replace("'",@"\'")}'";
        }
        public static string FormatDate(this string insertValue)
        {
            return $"'{insertValue.Substring(0, 4)}-{insertValue.Substring(4, 2)}-{insertValue.Substring(6, 2)}'";
        }
    }
}
