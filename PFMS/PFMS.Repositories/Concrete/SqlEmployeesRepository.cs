using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFMS.Entities;
using PFMS.Entities.DTO;

namespace PFMS.Repositories.Concrete
{
    public class SqlEmployeesRepository : BaseRepository, IEmployeesRepository
    {
        public SqlEmployeesRepository(PintingFactoryDBEntities context) : base(context)
        {

        }
        public void Delete(Employee entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public IEnumerable<Employee> Get(Func<Employee, bool> criteria = null)
        {
            var result = criteria == null ? context.Employees : context.Employees.Where(criteria);
            return result;
        }

        public IEnumerable<EmpInfoDTO> GetEmpInfo(Func<Person, bool> criteria = null)
        {
            var resultEntities = criteria != null ? from emp in context.Employees
                                                    join person in context.Persons on emp.PersonId equals person.ID
                                                    join position in context.EmpPositions on emp.PositionId equals position.Id
                                                    where criteria(person)
                                                    select new EmpInfoDTO
                                                    {
                                                        Id = emp.PersonId,
                                                        Name = person.FirstName + " " + person.LastName,
                                                        Address = person.Address,
                                                        Phone = person.PhoneNumber,
                                                        Position = position.PositionTitle,
                                                        Salary = position.Salary,
                                                        DateOfBirth = person.DateOfBirth,
                                                        Machines = emp.PrintingMachines.Select(pm => new PrintingMachineDTO
                                                        {
                                                            Id = pm.Id,
                                                            Model = pm.Model,
                                                            Price = pm.Price,
                                                            MachineType = pm.TypesOfMachine.TypeTitle
                                                        })
                                                    } :
                                                    from emp in context.Employees
                                                    join person in context.Persons on emp.PersonId equals person.ID
                                                    join position in context.EmpPositions on emp.PositionId equals position.Id
                                                    select new EmpInfoDTO
                                                    {
                                                        Id = emp.PersonId,
                                                        Name = person.FirstName + " " + person.LastName,
                                                        Address = person.Address,
                                                        Phone = person.PhoneNumber,
                                                        Position = position.PositionTitle,
                                                        Salary = position.Salary,
                                                        DateOfBirth = person.DateOfBirth,
                                                        Machines = emp.PrintingMachines.Select(pm => new PrintingMachineDTO
                                                        {
                                                            Id = pm.Id,
                                                            Model = pm.Model,
                                                            Price = pm.Price,
                                                            MachineType = pm.TypesOfMachine.TypeTitle
                                                        })
                                                    };
            return resultEntities;
        }

        public Employee GetSingle(Func<Employee, bool> criteria)
        {
            var resultEntity = criteria == null ? context.Employees.FirstOrDefault() : context.Employees.Where(criteria).FirstOrDefault();
            return resultEntity;
        }

        public int Insert(Employee entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            return entity.PersonId;
        }

        public Employee Update(Employee entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }

        public int GetCountOfRecords(Func<Employee, bool> criteria = null)
        {
            return criteria == null ? context.Employees.Count() : context.Employees.Where(criteria).Count();
        }
    }
}
