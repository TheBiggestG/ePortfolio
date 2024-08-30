using RandallDiscordBotUI_Revision.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace RandallDiscordBotUI_Revision.Model.Models;

public partial class UserAccessToServer : BaseDBClass
{
    public int? FkServerId { get; set; }

    public int? FkUserLoginId { get; set; }

    public virtual DiscordServer? FkServer { get; set; }

    public virtual UserLogin? FkUserLogin { get; set; }
}
