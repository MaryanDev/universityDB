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
        private SqlProductsToMachinesRepository _prodMachineRepo;
        private SqlPrintingMachineRepository _machineRepo;
        private SqlMachineTypeRepository _machineTypeRepo;
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

        public SqlProductsToMachinesRepository ProdMachineRepo
        {
            get
            {
                if(_prodMachineRepo == null)
                {
                    _prodMachineRepo = new SqlProductsToMachinesRepository(_context);
                }
                return _prodMachineRepo;
            }
        }

        public SqlPrintingMachineRepository MachineRepo
        {
            get
            {
                if(_machineRepo == null)
                {
                    _machineRepo = new SqlPrintingMachineRepository(_context);
                }
                return _machineRepo;
            }
        }

        public SqlMachineTypeRepository MachineTypeRepo
        {
            get
            {
                if(_machineTypeRepo == null)
                {
                    _machineTypeRepo = new SqlMachineTypeRepository(_context);
                }
                return _machineTypeRepo;
            }
        }

        #endregion
    }
}
