using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModule
{
    public class SQLQueries
    {
        public List<Converter_Saves> GetTop3ResultsOfConverter(DateTime from, DateTime to, string ConverterName)
        {
            List<Converter_Saves> data_records;
            using (ConverterDataEntities context = new ConverterDataEntities())
            {
                data_records = context.Converter_Saves
                    .Where(e => (e.DateTime > from && e.DateTime < to) && (e.Converter == ConverterName))
                    .OrderByDescending(e => e.DateTime)
                    .Take(3)
                    .ToList();
            }
            return data_records;
        }

        public List<Converter_Saves> SortFromToDate(DateTime from, DateTime to)
        {
            List<Converter_Saves> data_records;
            using (ConverterDataEntities context = new ConverterDataEntities())
            {
                data_records = context.Converter_Saves
                    .Where(e => e.DateTime > from && e.DateTime < to)
                    .OrderByDescending(e => e.DateTime)
                    .Take(20)
                    .ToList();
            }
            return data_records;
        }

        public List<Converter_Saves> SortByConverter(string ConverterName)
        {
            List<Converter_Saves> data_records;
            using (ConverterDataEntities context = new ConverterDataEntities())
            {
                data_records = context.Converter_Saves
                    .Where(d => d.Converter == ConverterName)
                    .OrderByDescending(e => e.DateTime)
                    .Take(20)
                    .ToList();
            }
            return data_records;
        }

        public List<Converter_Saves> GetData()
        {
            List<Converter_Saves> data_records;
            using (ConverterDataEntities context = new ConverterDataEntities())
            {
                data_records = context.Converter_Saves
                    .Take(20)
                    .ToList();
            }
            return data_records;
        }

        public void save_to_DB(string Converter, string UnitFrom, string UnitTo, string ValueToConvert, string ConvertedValue, DateTime Date)
        {

            using (ConverterDataEntities context = new ConverterDataEntities())
            {
                Converter_Saves newSave = new Converter_Saves()
                {
                    Converter = Converter,
                    UnitFrom = UnitFrom,
                    UnitTo = UnitTo,
                    ValueToConvert = ValueToConvert,
                    ConvertedValue = ConvertedValue,
                    DateTime = Date
                };
                context.Converter_Saves.Add(newSave);
                context.SaveChanges();
            }
        }

        public void save_rating(int? Rating)
        {
            int previous_id = 0;
            using (ConverterDataEntities context = new ConverterDataEntities())
            {
                previous_id = context.Ratings
                    .Count();

                var previous_rating = context.Ratings.First(c => c.id >= 0);
                context.Ratings.Remove(previous_rating);
                context.SaveChanges();

                Rating newSave = new Rating()
                {
                    Rating1 = Rating
                };
                context.Ratings.Add(newSave);
                context.SaveChanges();
            }
            
        }

        public int? load_rating()
        {
            int? rating = 0;
            using (ConverterDataEntities context = new ConverterDataEntities())
            {
                var vRating = context.Ratings.OrderByDescending(u => u.Rating1).Select(u => u.Rating1).FirstOrDefault();
                rating = vRating;
            }
            return rating;
        }
        
    }
}
