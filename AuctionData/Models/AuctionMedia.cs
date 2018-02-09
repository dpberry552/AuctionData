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
    [Table("AA_AuctionMedia")]
    public class AuctionMedia : BusinessObject, IDeletable
    {
        public int AuctionId { get; set; }
        public int MediaId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public static IEnumerable<AuctionMedia> GetByAuctionId(IDbConnection db, int auctionId)
        {
            return db.Query<AuctionMedia>(@"select * from AA_AuctionMedia where AuctionId = @id order by rank", new { id = auctionId });
        }
    }
}
