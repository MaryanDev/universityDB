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
    }
}
