using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data;
using AuctionData.Interfaces;
using System.Xml.Serialization;
using System.IO;

namespace AuctionData.Models
{
    public abstract class BusinessObject<T>
    {
        [Key]
        public int Id { get; set; }
        [XmlIgnore]
        public DateTime LastModified { get; set; }
        public DateTime WhenCreated { get; set; }

        public static T GetById<T>(IDbConnection db, int id)
            where T : BusinessObject<T>
        {
            return db.Get<T>(id);
        }

        public static IEnumerable<T> GetAll<T>(IDbConnection db)
            where T : BusinessObject<T>
        {
            return GetAll<T>(db, false, false);
        }

        public static IEnumerable<T> GetAll<T>(IDbConnection db, bool includeDeletes, bool includeHistory)
            where T : BusinessObject<T>
        {
            var isDeletable = typeof(IDeletable).IsAssignableFrom(typeof(T));
            var maintainHistory = typeof(IHistoricalData).IsAssignableFrom(typeof(T));

            IEnumerable<T> deletesHandled = db.GetAll<T>().Where(i => !isDeletable || (!(i as IDeletable).IsDeleted || includeDeletes));

            return deletesHandled.Where(i => !maintainHistory || (i as IHistoricalData).ValidToDate > DateTime.Now || includeHistory);
        }

        public bool Persist<T>(IDbConnection db)
            where T : BusinessObject<T>
        {

            //flag to indicate whether this object implements the IHistoricalData interface
            var maintainHistory = typeof(IHistoricalData).IsAssignableFrom(typeof(T));

            if (Id > 0)
            {
                //if the new incoming version of the record is the different than the one existing in the db...
                if (!this.EqualsCurrentVersion<T>(db))
                {
                    LastModified = DateTime.Now;
                    //if we maintain history for this object...
                    if (maintainHistory)
                    {
                        T curr = GetById<T>(db, Id);
                        //set ValidToDate and MasterId fields appropriately for existing and new versions of the object
                        (curr as IHistoricalData).ValidToDate = DateTime.Now;
                        (this as IHistoricalData).MasterId = Id;
                        (curr as IHistoricalData).MasterId = Id;
                        curr.Id = 0;
                        //update the existing (now historical) version and insert the new version
                        db.Update(this);
                        db.Insert(curr);
                    }
                    //if we are not maintaining history for this object...
                    else
                    {
                        db.Update(this);
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            //the record does not already exist in the db
            else
            {
                Console.WriteLine("object already exists in the db");
                WhenCreated = DateTime.Now;
                db.Insert(this);
                return false;
            }
        }


        public bool EqualsCurrentVersion<T>(IDbConnection db)
            where T : BusinessObject<T>
        {
            T curr = GetById<T>(db, Id);
            string newVersion = this.Serialize();
            string currVersion = curr.Serialize();
            Console.WriteLine(newVersion);
            Console.WriteLine(currVersion);
            return newVersion == currVersion;
        }

        private string Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, this);
                return sw.ToString();
            }
        }

    }
}


