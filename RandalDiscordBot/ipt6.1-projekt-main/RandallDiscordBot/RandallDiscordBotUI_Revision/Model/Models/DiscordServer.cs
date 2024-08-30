using RandallDiscordBotUI_Revision.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace RandallDiscordBotUI_Revision.Model.Models;

public partial class DiscordServer : InternalIdClass
{
    public virtual ICollection<UserAccessToServer> UserAccessToServers { get; set; } = new List<UserAccessToServer>();

    public virtual ICollection<UserIsInServer> UserIsInServers { get; set; } = new List<UserIsInServer>();
}
