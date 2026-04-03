using System;
using System.Collections.Generic;

namespace Hostelmanagement.Models;

public partial class Hostel
{
    public int HostelId { get; set; }

    public string? HostelName { get; set; }

    public int? RoomNo { get; set; }

    public virtual Student? Student { get; set; }
}
