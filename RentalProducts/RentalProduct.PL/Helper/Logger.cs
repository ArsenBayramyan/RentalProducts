using RentalProducts.DAL.Contexts;
using RentalProducts.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalProduct.PL.Helper
{
    public static class Logger
    {
        public static void WriteLog(Exception ex,ApplicationDbContext context)
        {
            ErrorLog errorLog = new ErrorLog
            {
                Message = ex.Message,
                Source = ex.Source,
                CreatedDate = DateTime.Now
            };
            context.ErrorLogs.Add(errorLog);
            context.SaveChanges();
        }
    }
}
