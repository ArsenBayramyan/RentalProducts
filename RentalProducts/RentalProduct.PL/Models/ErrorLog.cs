using RentalProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentalProducts.PL.Models
{
    public class ErrorLog : IModel
    {
        public int Id { get; set ; }
        public string Message { get ; set ; }
        public string Source { get; set ; }
        public DateTime CreatedDate { get ; set ; }
    }
}
