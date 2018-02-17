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
    public abstract class BusinessObject
    {
        [Key]
        public int Id { get; set; }
        [XmlIgnore]
        public DateTime LastModified { get; set; }
        public DateTime WhenCreated { get; set; }

        public static T GetById<T>(IDbConnection db, int id)
            where T : BusinessObject
        {
            return db.Get<T>(id);
        }

        public static IEnumerable<T> GetAll<T>(IDbConnection db)
            where T : BusinessObject
        {
            return GetAll<T>(db, false, false);
        }

        public static IEnumerable<T> GetAll<T>(IDbConnection db, bool includeDeletes, bool includeHistory)
            where T : BusinessObject
        {
            var isDeletable = typeof(IDeletable).IsAssignableFrom(typeof(T));
            var maintainHistory = typeof(IHistoricalData).IsAssignableFrom(typeof(T));

            IEnumerable<T> deletesHandled = db.GetAll<T>().Where(i => !isDeletable || (!(i as IDeletable).IsDeleted || includeDeletes));

            return deletesHandled.Where(i => !maintainHistory || (i as IHistoricalData).ValidToDate > DateTime.Now || includeHistory);
        }

        public static bool Persist<T>(IDbConnection db, T t)
            where T : BusinessObject
        {

            //flag to indicate whether this object implements the IHistoricalData interface
            var maintainHistory = typeof(IHistoricalData).IsAssignableFrom(typeof(T));

            if (t.Id > 0)
            {
                //if the new incoming version of the record is the different than the one existing in the db...
                if (!t.EqualsCurrentVersion<T>(db))
                {
                    t.LastModified = DateTime.Now;
                    //if we maintain history for this object...
                    if (maintainHistory)
                    {
                        T curr = GetById<T>(db, t.Id);
                        //set ValidToDate and MasterId fields appropriately for existing and new versions of the object
                        (curr as IHistoricalData).ValidToDate = DateTime.Now;
                        //(t as IHistoricalData).MasterId = t.Id;
                        (curr as IHistoricalData).MasterId = t.Id;
                        //t.Id = 0;
                        //update the existing (now historical) version and insert the new version
                        db.Update<T>(t);
                        db.Insert<T>(curr);
                    }
                    //if we are not maintaining history for this object...
                    else
                    {
                        db.Update(t);
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
                //Console.WriteLine("object does not exist in the db");
                t.WhenCreated = DateTime.Now;
                t.LastModified = DateTime.Now;
                //Console.WriteLine(t.Serialize());
                //Console.WriteLine("Object type: " + t.GetType());
                db.Insert<T>(t);
                return false;
            }
        }

        public static bool Delete<T>(IDbConnection db, T t)
            where T : BusinessObject
        {
            var isDeletable = typeof(IDeletable).IsAssignableFrom(typeof(T));
            if(isDeletable)
            {
                (t as IDeletable).IsDeleted = true;
                t.LastModified = DateTime.Now;
                db.Update<T>(t);
                return true;
            }
            else
            {
                //cascading delete logic handled on the DB side
                db.Delete<T>(t);
                return false;
            }
        }

        public bool EqualsCurrentVersion<T>(IDbConnection db)
            where T : BusinessObject
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


