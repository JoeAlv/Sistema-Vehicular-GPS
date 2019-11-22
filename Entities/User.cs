using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[DataContract]
public class User
{
    public User() { }
    [DataMember]

    public string UserID { get; set; }
    [MaxLength(50)]
    [DataMember]

    public string email { get; set; }
    [MaxLength(200), MinLength(3)]
    [DataMember]

    public string passwd { get; set; }
    [MaxLength(255), MinLength(3)]
    [DataMember]

    public string remember_token { get; set; }
    [MaxLength(255), MinLength(3)]
    [DataMember]

    public string name { get; set; }
    [MaxLength(50), MinLength(3)]
    [DataMember]

    public string lastname { get; set; }
    [MaxLength(50), MinLength(3)]
    [DataMember]

    public DateTime dateofborn { get; set; }
    [DataMember]

    public string nationality { get; set; }
    [MaxLength(50), MinLength(3)]
    [DataMember]

    public string phone { get; set; }
    [MaxLength(50), MinLength(3)]
    [DataMember]

    public DateTime created_at { get; set; }
    [DataMember]

    public DateTime updated_at { get; set; }
    [DataMember]

    public int ConditionID { get; set; }
    [MaxLength(20)]
    [DataMember]

    public int RoleID { get; set; }
    [MaxLength(20)]
    [DataMember]

    public int DriverLicenseID { get; set; }
    [MaxLength(20)]
    [DataMember]
        
    public List<User> users { get; set; }

}

