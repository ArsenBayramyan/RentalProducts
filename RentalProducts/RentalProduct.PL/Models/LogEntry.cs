using RentalProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalProducts.PL.Models
{
    public class LogEntry : IModel
    {
        public int Id { get ; set ; }
        public string Message { get; set ; }
        public DateTime CreatedDate { get; set ; }
    }
}
