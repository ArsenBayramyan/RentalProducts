﻿using RentalProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentalProducts.DAL.Models
{
    public class LogEntry : IModel
    {
        [Key]
        public int Id { get ; set ; }
        public string Message { get; set ; }
        public DateTime CreatedDate { get; set ; }
    }
}
