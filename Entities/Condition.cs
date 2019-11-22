using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[DataContract]
public class Condition
{
    public Condition() { }
    [DataMember]

    public int ConditionID { get; set; }
    [MaxLength(10)]
    [DataMember]

    public string title { get; set; }
    [MaxLength(50)]
    [DataMember]

    public List<Condition> conditions { get; set; }

}

