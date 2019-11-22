using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[DataContract]
public class Vehicle
{
    public Vehicle() { }
    [DataMember]

    public string VehicleID { get; set; }
    [MaxLength(50)]
    [DataMember]

    public string type { get; set; }
    [MaxLength(50)]
    [DataMember]

    public string brand { get; set; }
    [MaxLength(50), MinLength(3)]
    [DataMember]

    public DateTime year { get; set; }
    [MaxLength(20), MinLength(3)]
    [DataMember]

    public string engine { get; set; }
    [MaxLength(50), MinLength(3)]
    [DataMember]

    public string transmission { get; set; }
    [MaxLength(50), MinLength(3)]
    [DataMember]

    public string fuel { get; set; }
    [MaxLength(30), MinLength(3)]
    [DataMember]

    public float fueltank { get; set; }
    [MaxLength(20), MinLength(3)]
    [DataMember]

    public DateTime created_at { get; set; }
    [DataMember]

    public int ConditionID { get; set; }
    [MaxLength(20)]
    [DataMember]

    public List<Vehicle> vehicles { get; set; }

}