using RandallDiscordBotUI_Revision.Model.Models.BaseClasses;
using System;
using System.Collections.Generic;

namespace RandallDiscordBotUI_Revision.Model.Models;

public partial class Complaint : TextClass
{

    public int? FkComplaintTypeId { get; set; }

    public int? FkUserLoginId { get; set; }

    public virtual ComplaintType? FkComplaintType { get; set; }

    public virtual UserLogin? FkUserLogin { get; set; }
}
