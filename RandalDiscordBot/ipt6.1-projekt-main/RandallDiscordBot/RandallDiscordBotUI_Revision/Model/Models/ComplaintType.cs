using RandallDiscordBotUI_Revision.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace RandallDiscordBotUI_Revision.Model.Models;

public partial class ComplaintType : NameClass
{
    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
}
