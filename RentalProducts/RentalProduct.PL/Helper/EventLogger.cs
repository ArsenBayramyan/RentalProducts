using RentalProducts.DAL.Models;
using RentalProducts.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalProduct.PL.Helper
{
    public static class EventLogger
    {
        public static void WriteLog(string message,ApplicationDbContext context)
        {
            LogEntry logEntry = new LogEntry
            {
                Message = message,
                CreatedDate = DateTime.Now
            };
            context.LogEntries.Add(logEntry);
            context.SaveChanges();
        }
    }
}
