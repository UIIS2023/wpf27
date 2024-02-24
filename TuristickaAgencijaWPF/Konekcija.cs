using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace TuristickaAgencijaWPF
{
    internal class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {

            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder
            {
                DataSource = @"DESKTOP-SPOKL74\SQLEXPRESS",
                InitialCatalog = "TuristickaAgencija",
                IntegratedSecurity = true
            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }
    }
}
