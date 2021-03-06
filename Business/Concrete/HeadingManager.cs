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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }
        public void Delete(Heading entity)
        {
            _headingDal.Delete(entity);
        }

        public List<Heading> GetAll()
        {
            return _headingDal.List();
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public void Insert(Heading entity)
        {
            _headingDal.Insert(entity);
        }

        public void Update(Heading entity)
        {
            _headingDal.Update(entity);
        }
    }
}
