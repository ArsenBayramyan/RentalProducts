using AutoMapper;
using RentalProducts.Core.Interfaces;
using RentalProducts.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalProducts.BLL.Repository
{
    public class UnitOfWorkRepository
    {
        public ProductRepository productRepository;
        public OrderRepository orderRepository;
        public CustomerRepository customerRepository;
        public UnitOfWorkRepository(ApplicationDbContext dbContext)
        {
            productRepository = new ProductRepository(dbContext);
            orderRepository = new OrderRepository(dbContext);
            customerRepository = new CustomerRepository(dbContext);
        }
    }
}
