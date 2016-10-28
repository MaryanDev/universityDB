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
        #region Context
        private PintingFactoryDBEntities _context;
        #endregion
        #region Private repository fields
        private IPersonRepository _personRepo;
        private IEmployeesRepository _employeeRepo;
        private IPositionRepository _positionRepo;
        #endregion

        #region Constructors
        public UnitOfWork(PintingFactoryDBEntities context)
        {
            this._context = context;
        }
        #endregion

        #region Save changes
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion

        #region Public repository peoperties
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

        public IPositionRepository PositionRepo
        {
            get
            {
                if(_positionRepo == null)
                {
                    _positionRepo = new SqlPostionsRepository(_context);
                }
                return _positionRepo;
            }
        }
        #endregion
    }
}
