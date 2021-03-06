﻿using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMS.Entities;
using PFMS.Entities.DTO;

namespace PFMS.Repositories.Concrete
{
    public class SqlCustomersRepository : BaseRepository<Customer>, ICustomersRepository
    {
        public SqlCustomersRepository(PintingFactoryDBEntities context) : base(context)
        {

        }

        public IEnumerable<CustomerInfoDTO> GetSimpleCustomerInfo(Func<Customer, bool> criteria = null)
        {
            var resultEntities = criteria != null ? context.Customers.Where(criteria).Join(context.Persons, cus => cus.PersonId, per => per.ID, (cus, per) => new CustomerInfoDTO
            {
                Id = cus.PersonId,
                FirstName = per.FirstName,
                LastName = per.LastName,
                AccountNumber = cus.AccountNumber
            }) :
            context.Customers.Join(context.Persons, cus => cus.PersonId, per => per.ID, (cus, per) => new CustomerInfoDTO
            {
                Id = cus.PersonId,
                FirstName = per.FirstName,
                LastName = per.LastName,
                AccountNumber = cus.AccountNumber
            });
            return resultEntities;
        }

        public CustomerFullInfoDTO GetFullCustomerInfo(Func<Customer, bool> criteria)
        {
            var resultEntity = context.Customers.Where(criteria).Join(context.Persons, cus => cus.PersonId, person => person.ID, (cus, person) => new { cus, person })
                .Join(context.Orders, combined => combined.cus.PersonId, order => order.CustomerId, (combined, order) => new { combined, order })
                .Join(context.Products, combined1 => combined1.order.ProductId, prod => prod.Id, (combined1, prod) => new CustomerFullInfoDTO
                {
                    Id = combined1.combined.cus.PersonId,
                    FirstName = combined1.combined.person.FirstName,
                    LastName = combined1.combined.person.LastName,
                    DateOfBirth = combined1.combined.person.DateOfBirth.ToString("MM/dd/yyyy"),
                    Phone = combined1.combined.person.PhoneNumber,
                    Address = combined1.combined.person.Address,
                    AccountNumber = combined1.combined.cus.AccountNumber,
                    Orders = combined1.combined.cus.Orders.Select(pr => new OrderDTO
                    {
                        Id = prod.Id,
                        ProductTitle = prod.Title,
                        Quantity = combined1.order.Quantity
                    })
                });
            if (resultEntity.FirstOrDefault() == null)
            {
                resultEntity = context.Customers.Where(criteria).Join(context.Persons, cus => cus.PersonId, person => person.ID, (cus, person) => new CustomerFullInfoDTO
                {
                    Id = cus.PersonId,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    DateOfBirth = person.DateOfBirth.ToString("MM/dd/yyyy"),
                    Phone = person.PhoneNumber,
                    Address = person.Address,
                    AccountNumber = cus.AccountNumber
                });
            }

            return resultEntity.FirstOrDefault();
        }
    }
}
