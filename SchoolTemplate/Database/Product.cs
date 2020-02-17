﻿using System;

namespace SchoolTemplate.Database
{
  public class Product
  {
    public int id { get; set; }
    
    public string naam { get; set; }

    public string informatie { get; set; }    

    /// hallootjes wouter
    /// Gebruik altijd decimal voor geldzaken. Dit doe je om te voorkomen dat er afrondingsfouten optreden
    /// </summary>

    public DateTime datum { get; set; }

  }
}
