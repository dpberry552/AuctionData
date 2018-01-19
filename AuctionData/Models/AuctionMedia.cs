using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using AuctionData.Interfaces;

namespace AuctionData.Models
{
    [Table("AA_AuctionMedia")]
    class AuctionMedia : BusinessObject<AuctionMedia>, IDeletable
    {
        public int AuctionId { get; set; }
        public int MediaId { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
    }
}
