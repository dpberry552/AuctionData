using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using AuctionData.Interfaces;

namespace AuctionData.Models
{
    [Table("AA_ItemMedia")]
    public class ItemMedia : BusinessObject<ItemMedia>, IDeletable
    {
        public int ItemId { get; set; }
        public string Type { get; set; }
        public int MediaId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
