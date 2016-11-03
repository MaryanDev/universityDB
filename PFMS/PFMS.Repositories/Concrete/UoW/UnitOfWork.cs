using PFMS.Entities;
using PFMS.Repositories.Abstract;
using PFMS.Repositories.Concrete;
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
        private SqlPersonRepository _personRepo;
        private SqlEmployeesRepository _employeeRepo;
        private SqlPositionsRepository _positionRepo;
        private SqlCustomersRepository _customerRepo;
        private SqlProductsRepository _productRepo;
        private SqlOrderRepository _orderRepo;
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
        public SqlPersonRepository PersonRepo
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

        public SqlEmployeesRepository EmployeeRepo
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

        public SqlPositionsRepository PositionRepo
        {
            get
            {
                if(_positionRepo == null)
                {
                    _positionRepo = new SqlPositionsRepository(_context);
                }
                return _positionRepo;
            }
        }

        public SqlCustomersRepository CustomerRepo
        {
            get
            {
                if(_customerRepo == null)
                {
                    _customerRepo = new SqlCustomersRepository(_context);
                }
                return _customerRepo;
            }
        }

        public SqlProductsRepository ProductRepo
        {
            get
            {
                if(_productRepo == null)
                {
                    _productRepo = new SqlProductsRepository(_context);
                }
                return _productRepo;
            }
        }

        public SqlOrderRepository OrderRepo
        {
            get
            {
                if (_orderRepo == null)
                {
                    _orderRepo = new SqlOrderRepository(_context);
                }
                return _orderRepo;
            }
        }

        #endregion
    }
}
