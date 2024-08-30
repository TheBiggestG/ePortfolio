using SQLiteInserts.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace SQLiteInserts.Models;

public partial class UserLog: TextClass
{
    public int? FkLogTypeId { get; set; }

    public int? FkDiscordUserId { get; set; }

    public virtual DiscordUser? FkDiscordUser { get; set; }

    public virtual LogType? FkLogType { get; set; }
}
