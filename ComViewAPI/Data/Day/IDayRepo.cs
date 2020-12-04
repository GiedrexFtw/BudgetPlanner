using ComView.Dto;
using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public interface IDayRepo
    {
        IEnumerable<Day> GetDayList();
        Day GetDayById(int id);
        void CreateDay(Day day);
        bool SaveChanges();
        void UpdateDay(Day day);
        void DeleteDay(Day day);
        void CheckProducts(Day dayToUpdate);
    }
}
