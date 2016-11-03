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
        private ICustomersRepository _customerRepo;
        private IProductsRepository _productRepo;
        private IOrderRepository _orderRepo;
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

        public ICustomersRepository CustomerRepo
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

        public IProductsRepository ProductRepo
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

        public IOrderRepository OrderRepo
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
