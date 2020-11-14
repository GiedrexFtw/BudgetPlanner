using ComView.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public class SqlReportRepo : IReportRepo
    {
        private readonly ApplicationContext _appContext;

        public SqlReportRepo(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public void CreateReport(Report report)
        {
            if (report != null)
            {
                _appContext.Reports.Add(report);
            }
            else
                throw new ArgumentException();
        }

        public void DeleteReport(Report report)
        {
            if(report == null)
            {
                throw new ArgumentNullException();
            }
            _appContext.Reports.Remove(report);
            
        }

        public Report GetReportById(int id, int dayId, int productId)
        {
            return _appContext.Reports.Include(r => r.Days)
                .ThenInclude(r=>r.Products).Where(r=>r.Days.Any(t=>t.Id == dayId)).FirstOrDefault(r => r.Id == id );
        }
        public Report GetReportById(int id)
        {
            return _appContext.Reports.Include(r => r.Days)
                .ThenInclude(r => r.Products).FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Report> GetReportList()
        {
            return _appContext.Reports.Include(r=>r.Days).ThenInclude(r=>r.Products).ToList();
        }

        public bool SaveChanges()
        {
            return _appContext.SaveChanges() >= 0;
        }

        public void UpdateReport(Report report)
        {
            //
        }
    }
}
