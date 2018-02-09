using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using AuctionData.Interfaces;
using System.Data;
using Dapper;

namespace AuctionData.Models
{
    [Table("AA_Items")]
    public class Item : BusinessObject, IDeletable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool OnlineBidding { get; set; }
        public decimal MinimumBid { get; set; }
        public string LotNumber { get; set; }
        public int AuctionId { get; set; }
        public int Rank { get; set; }
        public bool IsDeleted { get; set; }

        public static IEnumerable<Item> GetByAuctionId(IDbConnection db, int auctionId)
        {
            return db.Query<Item>(@"select * from AA_Items where AuctionId = @id order by rank", new { id = auctionId });
        }
    }
}
