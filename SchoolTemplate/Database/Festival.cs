using System;

namespace SchoolTemplate.Database
{
  public class Festival
  {
    public int Id { get; set; }
    
    public string Naam { get; set; }

    public string Korte_info { get; set; }

    public string Lange_info { get; set; }

    public DateTimeOffset Begin_datum { get; set; }

    public DateTimeOffset Eind_datum { get; set; }


    }
}
