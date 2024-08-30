using RandallDiscordBot.Components.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace RandallDiscordBot.Components.Model.Models;

public partial class UserIsInServer : BaseDBClass
{
    public int? FkServerId { get; set; }

    public int? FkDiscordUserId { get; set; }

    public virtual DiscordUser? FkDiscordUser { get; set; }

    public virtual DiscordServer? FkServer { get; set; }
}
