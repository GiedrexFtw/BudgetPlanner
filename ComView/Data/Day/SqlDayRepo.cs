using ComView.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public class SqlDayRepo : IDayRepo
    {
        private readonly ApplicationContext _appContext;

        public SqlDayRepo(ApplicationContext dayContext)
        {
            _appContext = dayContext;
        }

        public void CreateDay(Day day)
        {
            if (day != null)
            {
                _appContext.Days.Add(day);
            }
            else
                throw new ArgumentException();
        }

        public void DeleteDay(Day day)
        {
            if (day == null)
            {
                throw new ArgumentNullException();
            }
            _appContext.Days.Remove(day);

        }

        public Day GetDayById(int id)
        { 
            var day = _appContext.Days.Include(d=>d.Products).FirstOrDefault(p => p.Id == id);
            //var products = _appContext.Days.
            return day;
        }

        public IEnumerable<Day> GetDayList()
        {
            return _appContext.Days.Include(d => d.Products).ToList();
        }

        public bool SaveChanges()
        {
            return _appContext.SaveChanges() >= 0;
        }

        public void UpdateDay(Day day)
        {
            //
        }
    }
}
