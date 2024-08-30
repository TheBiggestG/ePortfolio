using RandallDiscordBot.Components.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace RandallDiscordBot.Components.Model.Models;

public partial class ComplaintType : NameClass
{
    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
}
