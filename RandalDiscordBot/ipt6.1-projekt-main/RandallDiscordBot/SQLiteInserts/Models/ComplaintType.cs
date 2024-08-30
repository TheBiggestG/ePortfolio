using SQLiteInserts.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace SQLiteInserts.Models;

public partial class ComplaintType: NameClass
{
    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
}
