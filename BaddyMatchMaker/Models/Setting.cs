using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Setting
    {
        public short? MatchDuration { get; protected set; }
        public bool? IgnoreSex { get; protected set; }
    }
}
