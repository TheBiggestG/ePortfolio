using RandallDiscordBot.Components.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace RandallDiscordBot.Components.Model.Models;

public partial class UserAccessToServer : BaseDBClass
{
    public int? FkServerId { get; set; }

    public int? FkUserLoginId { get; set; }

    public virtual DiscordServer? FkServer { get; set; }

    public virtual UserLogin? FkUserLogin { get; set; }
}
