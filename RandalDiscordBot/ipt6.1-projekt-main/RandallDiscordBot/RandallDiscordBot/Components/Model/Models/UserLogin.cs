using RandallDiscordBot.Components.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace RandallDiscordBot.Components.Model.Models;

public partial class UserLogin : NameClass
{
    public string? UserLoginPassword { get; set; }

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual ICollection<UserAccessToServer> UserAccessToServers { get; set; } = new List<UserAccessToServer>();
}
