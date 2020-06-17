using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GGAdvantage.Application
{
    public enum eAuctionTimeleft
    {
        Short = 3,    
        Long = 2, 
        VeryLong = 1
    }

    public enum eIconSize
    {
        [Description("small")]
        Small,
        [Description("large")]
        Large
    }

    public enum eActionState
    {
        None = 0,
        Insert = 1,
        Update = 2,
        Delete = 3
    }
}
