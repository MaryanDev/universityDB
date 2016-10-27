using PFMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Abstract
{
    public abstract class BaseRepository
    {
        protected PintingFactoryDBEntities context;

        public BaseRepository(PintingFactoryDBEntities context)
        {
            this.context = context;
        }

        //public BaseRepository(string connectionString)
        //{
        //    this.context = new PintingFactoryDBEntities(connectionString);
        //}
    }
}
