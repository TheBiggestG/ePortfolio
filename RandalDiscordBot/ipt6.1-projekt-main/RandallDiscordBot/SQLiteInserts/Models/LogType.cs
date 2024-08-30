using SQLiteInserts.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteInserts.Models;

public partial class LogType: NameClass
{
    public virtual ICollection<UserLog> UserLogs { get; set; } = new List<UserLog>();
}
