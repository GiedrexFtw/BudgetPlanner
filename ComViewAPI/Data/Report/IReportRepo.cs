using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public interface IReportRepo
    {
        IEnumerable<Report> GetReportList();
        Report GetReportById(int id, int dayId, int productId);
        Report GetReportById(int id);
        void CreateReport(Report report);
        bool SaveChanges();
        void UpdateReport(Report report);
        void DeleteReport(Report report);

    }
}
