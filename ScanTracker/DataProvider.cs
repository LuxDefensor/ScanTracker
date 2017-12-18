using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ScanTracker
{
    class DataProvider
    {
        private string cs;

        public DataProvider()
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = ".";
            csb.InitialCatalog = "askue_stavropolenergo";
            csb.IntegratedSecurity = true;
            cs = csb.ConnectionString;
        }

        public List<USPD> ActiveUSPD
        {
        get
            {
                List<USPD> result = new List<USPD>();
                using (SqlConnection cn = new SqlConnection(cs))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = @"with cte as
(select u.ID_USPD,u.Name,u.TypeCommun,u.NumCOMPort,
m.DT,e.Txt event,c.Txt comment
from protocol_main m
left join protocol_event e on e.ID_Event=m.ID_Event
left join protocol_comment c on c.ID_Comment=m.ID_Comment
left join protocol_source s on s.ID_Source=m.ID_Source
left join usd u on u.Name=s.Txt
where u.ID_Scanner=1 and u.TypeCommun='AT-Modem  ')
 
select cte.* from cte
inner join
(      select TypeCommun,NumCOMPort,max(dt) [date]
       from cte
       group by TypeCommun,NumCOMPort) t
on t.NumCOMPort=cte.NumCOMPort and cte.TypeCommun=t.TypeCommun
   and cte.DT=t.date
order by numcomport";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(new USPD()
                        {
                            ID_uspd = dr[0].ToString(),
                            Name = dr[1].ToString(),
                            TypeCommun = dr[2].ToString(),
                            COMPort = dr[3].ToString(),
                            Date = dr[4].ToString(),
                            Event = dr[5].ToString(),
                            Comment = dr[6].ToString()
                        });
                    }
                    dr.Close();
                    return result; 
                }
            }
        }
    }
}
