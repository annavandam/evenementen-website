using System;

namespace SchoolTemplate.Database
{
  public class festival
  {
    public int id { get; set; }
    
    public string naam { get; set; }

    public string korte_info { get; set; }

    public string lange_info { get; set; }

    public DateTimeOffset begin_datum { get; set; }

    public DateTimeOffset eind_datum { get; set; }


    }
}
