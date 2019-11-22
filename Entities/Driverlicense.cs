using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[DataContract]
public class Driverlicense
{
    public Driverlicense() { }
    [DataMember]

    public string DriverlicenseID { get; set; }
    [MaxLength(20), MinLength(1)]
    [DataMember]

    public string description { get; set; }
    [MaxLength(50), MinLength(3)]
    [DataMember]
    
    public List<Driverlicense> driverlicenses { get; set; }

}