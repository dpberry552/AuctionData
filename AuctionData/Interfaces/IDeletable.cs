using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionData.Interfaces
{
    interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
