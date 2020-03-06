using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolTemplate.Database;
using SchoolTemplate.Models;

namespace SchoolTemplate.Controllers
{
  public class HomeController : Controller
  {
    // zorg ervoor dat je hier je gebruikersnaam (leerlingnummer) en wachtwoord invult
    string connectionString = "Server=172.16.160.21;Port=3306;Database=110274;Uid=110274;Pwd=rairLefs;";

    public IActionResult Index()
    {    
        List<Festival> festivals = GetFestivals();
            
        return View(festivals);
    }
        
    private List<Festival> GetFestivals()
        {
            List<Festival> festivals = new List<Festival>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Festival", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Festival f = new Festival
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Naam = reader["naam"].ToString(),
                            Informatie = reader["informatie"].ToString(),
                            Datum = DateTime.Parse(reader["datum"].ToString())
                        };
                        festivals.Add(f);
                    }
                }
            }

            return festivals;
        }


    public IActionResult Contact()
    {
        return View();
    }

    [Route("festival/{id}")]
    public IActionResult Festival(string id)
        {
            ViewData["id"] = id;
            return View();
        }

    public IActionResult Tickets()
    {
        return View();
    }
    public IActionResult LogIn()
    {
          return View();
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
