using System;

namespace SchoolTemplate.Database
{
  public class Festival
  {
    public int Id { get; set; }
    
    public string Naam { get; set; }

    public string Informatie { get; set; }

    public DateTimeOffset Datum { get; set; }

  }
}
