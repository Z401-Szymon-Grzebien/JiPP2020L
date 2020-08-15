using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModule
{

    public class SQLQueries
    {
        public void save_to_DB(int score, DateTime date)
        {

            using (SnekScoreBoardEntities context = new SnekScoreBoardEntities())
            {
                ScoreBoard s = new ScoreBoard()
                {
                    Score = score,
                    Date = date
                };
                context.ScoreBoards.Add(s);
                context.SaveChanges();
            }
        }

        public List<ScoreBoard> GetData()
        {
            List<ScoreBoard> data_records;
            using (SnekScoreBoardEntities context = new SnekScoreBoardEntities())
            {
                data_records = context.ScoreBoards
                    .ToList();
            }
            return data_records;
        }

        public List<ScoreBoard> GetTop10()
        {
            List<ScoreBoard> data_records;
            using (SnekScoreBoardEntities context = new SnekScoreBoardEntities())
            {
                data_records = context.ScoreBoards
                    .OrderByDescending(e => e.Score)
                    .Take(10)
                    .ToList();
            }
            return data_records;
        }
    }

}
