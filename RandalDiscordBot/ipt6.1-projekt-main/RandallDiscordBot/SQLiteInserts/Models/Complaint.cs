using SQLiteInserts.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace SQLiteInserts.Models;

public partial class Complaint : TextClass
{

    public int? FkComplaintTypeId { get; set; }

    public int? FkUserLoginId { get; set; }

    public virtual ComplaintType? FkComplaintType { get; set; }

    public virtual UserLogin? FkUserLogin { get; set; }
}
