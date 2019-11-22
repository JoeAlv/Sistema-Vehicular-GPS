using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[DataContract]
public class Role
{
    public Role() { }
    [DataMember]

    public int RoleID { get; set; }
    [MaxLength(10)]
    [DataMember]

    public string title { get; set; }
    [MaxLength(50)]
    [DataMember]

    public List<Role> roles { get; set; }

}

