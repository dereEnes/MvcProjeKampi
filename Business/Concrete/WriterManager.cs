using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void Delete(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.List();
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

        public void Insert(Writer entity)
        {
            _writerDal.Insert(entity);
        }

        public void Update(Writer entity)
        {
            _writerDal.Update(entity);
        }
    }
}
