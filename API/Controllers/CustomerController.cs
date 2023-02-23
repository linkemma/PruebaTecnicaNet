
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CustomerEntity = Business.Entities.Customer;
using System;
using System.Linq;
using AutoMapper;

namespace API.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        [HttpGet]
        public IQueryable<CustomerEntity> GetAll()
        {
            return CustomerService.GetAll();
        }


        [HttpPost]
        public CustomerEntity CreateCustomer(CustomerEntity entity)
        {
            return CustomerService.Create(entity);
        }

        [HttpPut]
        public CustomerEntity Update(CustomerEntity entity)
        {
            return CustomerService.Update(entity.CustomerId, entity, out bool changed);
        }

        [HttpDelete]
        public CustomerEntity Delete(CustomerEntity entity)
        {
            var ExistsPost = CustomerService.CustomerPost(entity.CustomerId);

            if(ExistsPost)
                 CustomerService.DeletePost(entity.CustomerId);

            var Del = CustomerService.Delete(entity);
               
            return Del;
        }
    }
}
