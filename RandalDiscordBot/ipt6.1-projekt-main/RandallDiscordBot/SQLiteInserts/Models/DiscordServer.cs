using SQLiteInserts.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace SQLiteInserts.Models;

public partial class DiscordServer: InternalIdClass
{
    public virtual ICollection<UserAccessToServer> UserAccessToServers { get; set; } = new List<UserAccessToServer>();

    public virtual ICollection<UserIsInServer> UserIsInServers { get; set; } = new List<UserIsInServer>();
}
