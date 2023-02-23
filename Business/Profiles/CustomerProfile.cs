using AutoMapper;
using Business.DTOs;
using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Profiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
