using AED.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;

namespace AED.Controllers
{
    
    public class AEDController : Controller
    {        
        
        public IActionResult Index(string s1) {
            string gu = s1;
            string connStr = "Server=3.36.169.130;Database=cloud;Uid=admin;Pwd=12341234;";            
            List<Data> list = new List<Data>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM gu WHERE addrs LIKE '%" + gu + "%' ";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Data()
                    {
                        number = Convert.ToInt32(rdr["number"]),
                        addrs = rdr["addrs"].ToString(),
                        Y = Convert.ToDouble(rdr["Y"]),
                        X = Convert.ToDouble(rdr["X"])
                    });
                }
                rdr.Close();
            } 
            return View(list);
        }
    }
}