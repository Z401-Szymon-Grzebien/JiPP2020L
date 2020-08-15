using System;
using System.Collections.Generic;
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
    }
}
