using System.Collections.Generic;

namespace Restaurant.Domain;

public class StationInstance
{
    public string Type { get; set; }
    public bool IsBusy { get; set; }
   

    public StationInstance(string type)
    {
        Type = type;
    }
}