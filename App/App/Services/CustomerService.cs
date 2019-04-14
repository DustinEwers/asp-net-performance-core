using App.DataAccess;
using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public interface ICustomerService {
        Task<List<string>> GetExtraCustomerDataFromService();
        Task<List<string>> GetMoreExternalCustomerDataFromService();
        Task<List<Customer>> GetCustomersAsync();
    }

    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public async Task<List<Customer>> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetExtraCustomerDataFromService()
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetMoreExternalCustomerDataFromService()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetCustomers() {
            return await _context.Customers
                .Include(x => x.Orders).ThenInclude(x => x.OrderLines)
                .ToListAsync();
        }
    }
}
