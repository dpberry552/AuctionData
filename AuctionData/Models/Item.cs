﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace AuctionData.Models
{
    [Table("AA_Items")]
    class Item : BusinessObject<Item>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool OnlineBidding { get; set; }
        public decimal MinimumBid { get; set; }
        public string LotNumber { get; set; }
        public int AuctionId { get; set; }
        public int Rank { get; set; }
        public bool IsDeleted { get; set; }
    }
}