using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[DataContract]
public class Travel
{
    public Travel() { }
    [DataMember]

    public int TravelID { get; set; }
    [MaxLength(20)]
    [DataMember]

    public string UserID { get; set; }
    [MaxLength(50)]
    [DataMember]

    public string VehicleID { get; set; }
    [MaxLength(50)]
    [DataMember]

    public int ConditionID { get; set; }
    [MaxLength(20)]
    [DataMember]

    public DateTime created_at { get; set; }
    [DataMember]

    public List<Travel> Travels { get; set; }

}


