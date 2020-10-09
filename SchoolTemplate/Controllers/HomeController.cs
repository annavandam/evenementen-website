using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolTemplate.Models;
using SchoolTemplate.Database;
using SchoolTemplate.Models;

namespace SchoolTemplate.Controllers
{
    public class HomeController : Controller
    {
        // zorg ervoor dat je hier je gebruikersnaam (leerlingnummer) en wachtwoord invult
        string connectionString = "Server=172.16.160.21;Port=3306;Database=110270;Uid=110270;Pwd=fAntuNfi;";

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
                MySqlCommand cmd = new MySqlCommand("select * from festival", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Festival f = new Festival
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Naam = reader["Naam"].ToString(),
                            Korte_info = reader["Korte_info"].ToString(),
                            Lange_info = reader["Lange_info"].ToString(),
                            Begin_datum = DateTime.Parse(reader["Begin_datum"].ToString()),
                            Eind_datum = DateTime.Parse(reader["Eind_datum"].ToString())
                        };
                        festivals.Add(f);
                    }
                }
            }
                return festivals;
        }

        private Festival GetFestival(string id)
        {
            List<Festival> festivals = new List<Festival>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"select * from festival where id = {id}", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Festival f = new Festival
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Naam = reader["Naam"].ToString(),
                            Korte_info = reader["Korte_info"].ToString(),
                            Lange_info = reader["Lange_info"].ToString(),
                            Begin_datum = DateTime.Parse(reader["Begin_datum"].ToString()),
                            Eind_datum = DateTime.Parse(reader["Eind_datum"].ToString())
                        };
                        festivals.Add(f);
                    }
                }
            }
            return festivals[0];
        }

        private Festival GetFisrstFestival(string id)
        {
            List<Festival> festivals = new List<Festival>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"select min(Begin_datum), id, naam from festival", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Festival f = new Festival
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Naam = reader["Naam"].ToString(),
                            Korte_info = reader["Korte_info"].ToString(),
                            Lange_info = reader["Lange_info"].ToString(),
                            Begin_datum = DateTime.Parse(reader["Begin_datum"].ToString()),
                            Eind_datum = DateTime.Parse(reader["Eind_datum"].ToString())
                        };
                        festivals.Add(f);
                    }
                }
            }
            return festivals[0];
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("contact")]
        [HttpPost]
        public IActionResult Contact(PersonModel model)
        {

            return View(model);
        }


        [Route("festival/{id}/{naam}")]
        public IActionResult Festival(string id)
        {
            var model = GetFestival(id);
            return View(model);
        }

        [Route("festival/{id}/{naam}")]
        [HttpPost]
        public IActionResult Festival(int id, string naam, string naampie)
        {
            ViewData["id"] = id;
            return View();
        }


        public IActionResult Tickets()
        {
            List<Festival> festivals = GetFestivals();
            ViewData["keuzes"] = festivals;
            return View(new PersonModel());

        }
        
        [HttpPost]
        public IActionResult Tickets(PersonModel model)
        {
            List<Festival> festivals = GetFestivals();
            ViewData["keuzes"] = festivals;
            return View(model);
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


