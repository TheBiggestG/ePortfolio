using RandallDiscordBot.Components.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RandallDiscordBot.Components.Model.Models;

public partial class DiscordUser : InternalIdClass
{
    public int? Points { get; set; }

    public virtual ICollection<UserIsInServer> UserIsInServers { get; set; } = new List<UserIsInServer>();

    public virtual ICollection<UserLog> UserLogs { get; set; } = new List<UserLog>();
}
