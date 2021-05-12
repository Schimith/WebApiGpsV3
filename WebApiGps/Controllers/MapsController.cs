using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using WebApiGps.Models;

namespace WebApiGps.Controllers
{
    public class MapsController : Controller
    {
        // GET: Home  
        public ActionResult Index()
        {
            string connectionString = "Server=DESKTOP-5A8O62Q;Database=EMPRESA;User ID=app;Password=123456;";


            string markers = "[";
            //string conString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
            SqlCommand cmd = new SqlCommand("SP_GPS");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        markers += "{";
                        markers += string.Format("'title': '{0}',", sdr["COD_CACAMBA"]);
                        markers += string.Format("'lat': '{0}',", sdr["LATITUDE"]);
                        markers += string.Format("'lng': '{0}',", sdr["LONGITUDE"]);
                        markers += string.Format("'description': '{0}',", sdr["CRIADO_EM"]);                        
                        markers += "},";
                    }
                }
                con.Close();
            }

            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }
    }
}
