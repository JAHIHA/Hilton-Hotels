﻿using Hilton_Hotels.Models;

namespace Hilton_Hotels.Services
{
    public interface ICustomerService
    {
        public void Add(CustomerModel costumer);
        public void Update(CustomerModel costumer);   
        public void Delete(string UserName);
        public List<CustomerModel> Get();
        public CustomerModel Find(string UserName);
    }
}