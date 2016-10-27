using PFMS.Entities;
using PFMS.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Concrete.UoW
{
    public class UnitOfWork
    {
        private PintingFactoryDBEntities _context;
        private IPersonRepository _personRepo;
        private IEmployeesRepository _employeeRepo;

        public UnitOfWork(PintingFactoryDBEntities context)
        {
            this._context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IPersonRepository PersonRepo
        {
            get
            {
                if(_personRepo == null)
                {
                    _personRepo = new SqlPersonRepository(_context);
                }
                return _personRepo;
            }
        }

        public IEmployeesRepository EmployeeRepo
        {
            get
            {
                if (_employeeRepo == null)
                {
                    _employeeRepo = new SqlEmployeesRepository(_context);
                }
                return _employeeRepo;
            }
        }

    }
}
