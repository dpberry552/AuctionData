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
    [Table("AA_ItemMedia")]
    public class ItemMedia : BusinessObject, IDeletable
    {
        public int ItemId { get; set; }
        public string Type { get; set; }
        public int MediaId { get; set; }
        public bool IsDeleted { get; set; }

        public static IEnumerable<ItemMedia> GetByAuctionId(IDbConnection db, int itemId)
        {
            return db.Query<ItemMedia>(@"select * from AA_ItemMedia where ItemId = @id order by rank", new { id = itemId });
        }
    }
}
