using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using AuctionData.Interfaces;
using System.Data;

namespace AuctionData.Models
{
    [Table("AA_Auctions")]
    public class Auction : BusinessObject,  IHistoricalData, IDeletable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AuctionDateTime { get; set; }
        public string Type { get; set; }
        public bool IsPublic { get; set; }
        public int LocationId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ValidToDate { get; set; }
        public int MasterId { get; set; }

    }
}
