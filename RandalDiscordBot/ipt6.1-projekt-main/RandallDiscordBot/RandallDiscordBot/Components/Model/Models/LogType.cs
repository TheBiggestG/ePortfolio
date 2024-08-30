using RandallDiscordBot.Components.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandallDiscordBot.Components.Model.Models;

public partial class LogType : NameClass
{
    public virtual ICollection<UserLog> UserLogs { get; set; } = new List<UserLog>();
}
