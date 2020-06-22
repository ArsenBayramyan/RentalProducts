using RentalProducts.Core.Interfaces;
using System;

namespace RentalProducts.BLL.Models
{
    public class LogEntry : IModel
    {
        public int Id { get ; set ; }
        public string Message { get; set ; }
        public DateTime CreatedDate { get; set ; }
    }
}
