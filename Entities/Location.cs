using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[DataContract]
public class Location
{
    public Location() { }
    [DataMember]

    public int LocationID { get; set; }
    [MaxLength(50)]
    [DataMember]

    public string name { get; set; }
    [MaxLength(100), MinLength(3)]
    [DataMember]

    public string address { get; set; }
    [MaxLength(200), MinLength(3)]
    [DataMember]

    public string latitude { get; set; }
    [MaxLength(50), MinLength(3)]
    [DataMember]

    public string longitude { get; set; }
    [MaxLength(100), MinLength(3)]
    [DataMember]

    public int TravelID { get; set; }
    [MaxLength(50)]
    [DataMember]

    public List<Location> locations { get; set; }

}

