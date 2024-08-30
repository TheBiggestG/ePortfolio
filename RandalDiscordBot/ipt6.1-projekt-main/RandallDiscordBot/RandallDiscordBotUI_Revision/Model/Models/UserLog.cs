using RandallDiscordBotUI_Revision.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace RandallDiscordBotUI_Revision.Model.Models;

public partial class UserLog : TextClass
{
    public int? FkLogTypeId { get; set; }

    public int? FkDiscordUserId { get; set; }

    public virtual DiscordUser? FkDiscordUser { get; set; }

    public virtual LogType? FkLogType { get; set; }
}
