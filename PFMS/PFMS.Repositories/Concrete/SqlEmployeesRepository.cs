﻿using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMS.Entities;
using PFMS.Entities.DTO;

namespace PFMS.Repositories.Concrete
{
    public class SqlEmployeesRepository : BaseRepository<Employee>, IEmployeesRepository
    {
        public SqlEmployeesRepository(PintingFactoryDBEntities context) : base(context)
        {

        }

        public IEnumerable<EmpInfoDTO> GetSimpleEmpInfo(Func<Employee, bool> criteria = null)
        {
            var resultEntities = criteria != null ? context.Employees.Where(criteria).Join(context.Persons, emp => emp.PersonId, per => per.ID, (emp, per) => new EmpInfoDTO
            {
                Id = emp.PersonId,
                FirstName = per.FirstName,
                LastName = per.LastName,
                Position = emp.EmpPosition.PositionTitle
            }) :
            context.Employees.Join(context.Persons, emp => emp.PersonId, per => per.ID, (emp, per) => new EmpInfoDTO
            {
                Id = emp.PersonId,
                FirstName = per.FirstName,
                LastName = per.LastName,
                Position = emp.EmpPosition.PositionTitle
            });
            return resultEntities;
        }

        public EmpFullInfoDTO GetFullEmpInfo(Func<Employee, bool> criteria)
        {
            var resultEntities = context.Employees.Where(criteria).Join(context.Persons, emp => emp.PersonId, person => person.ID, (emp, person) => new { emp, person })
                .Join(context.EmpPositions, combined => combined.emp.PositionId, position => position.Id, (combined, position) => new EmpFullInfoDTO
                {
                    Id = combined.emp.PersonId,
                    FirstName = combined.person.FirstName,
                    LastName = combined.person.LastName,
                    Address = combined.person.Address,
                    Phone = combined.person.PhoneNumber,
                    Position = position.PositionTitle,
                    Salary = position.Salary,
                    DateOfBirth = combined.person.DateOfBirth.ToString("MM/dd/yyyy"),
                    Machines = combined.emp.PrintingMachines.Select(pm => new PrintingMachineDTO
                    {
                        Id = pm.Id,
                        Model = pm.Model,
                        Price = pm.Price,
                        MachineType = pm.TypesOfMachine.TypeTitle
                    })
                });
            return resultEntities.SingleOrDefault();
        }
    }
}
