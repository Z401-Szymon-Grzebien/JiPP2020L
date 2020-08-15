using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseM
{
    public class SQLQueries
    {

        public void save_to_db(int score, DateTime date)
        {
            using (SnekScoreBoardEntities context = new SnekScoreBoardEntities())
            {
                ScoreBoard newSave = new ScoreBoard()
                {
                    Score = score,
                    Date = date
                };
                context.ScoreBoards.Add(newSave);
                context.SaveChanges();
            }
        }
        public List<ScoreBoard> GetTop10Scores()
        {
            List<ScoreBoard> data_records;
            using (SnekScoreBoardEntities context = new SnekScoreBoardEntities())
            {
                data_records = context.ScoreBoards
                    .OrderByDescending(e => e.id)
                    .Take(10)
                    .ToList();
            }
            return data_records;
        }
        public List<ScoreBoard> GetData()
        {
            List<ScoreBoard> data_records;
            using (SnekScoreBoardEntities context = new SnekScoreBoardEntities())
            {
                data_records = context.ScoreBoards
                    .Take(20)
                    .ToList();
            }
            return data_records;
        }

    }
}
