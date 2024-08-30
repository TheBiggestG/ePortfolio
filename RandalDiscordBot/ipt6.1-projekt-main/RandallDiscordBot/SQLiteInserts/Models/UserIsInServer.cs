using SQLiteInserts.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace SQLiteInserts.Models;

public partial class UserIsInServer: BaseDBClass
{
    public int? FkServerId { get; set; }

    public int? FkDiscordUserId { get; set; }

    public virtual DiscordUser? FkDiscordUser { get; set; }

    public virtual DiscordServer? FkServer { get; set; }
}
