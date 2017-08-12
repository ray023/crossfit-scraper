using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using o1solution.crossfitscraper.Models;
using System.IO;

namespace o1solution.crossfitscraper.Providers.MySql
{
    internal class MySqlProvider : IMySqlProvider
    {
        public string GetAffiliatePopulateSql(List<Affiliate> affiliateList)
        {
            var sql = new StringBuilder();
            sql.Append("DELETE FROM `affiliates`;")
               .Append("DELETE FROM `affiliate_courses`;");
            affiliateList.ForEach(x => sql.Append(x.GetMySqlInsertLine()));
            
            return sql.ToString();
        }

        public string GetEventPopulateSql(List<Event> eventList)
        {
            var sql = new StringBuilder();
            sql.Append("DELETE FROM `events`;");
            eventList.ForEach(x => sql.Append(x.GetMySqlInsertLine()));

            return sql.ToString();
        }
    }
}
