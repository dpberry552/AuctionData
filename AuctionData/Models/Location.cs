using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using AuctionData.Interfaces;

namespace AuctionData.Models
{
    [Table("AA_Locations")]
    class Location : BusinessObject<Location>, IDeletable
    {
        public string Title { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
    }
}
