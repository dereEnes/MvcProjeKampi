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
    public class ContentManager:IContentService
    {
        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public void Insert(Content entity)
        {
            _contentDal.Insert(entity);
        }

        public void Delete(Content entity)
        {
            _contentDal.Delete(entity);
        }

        public void Update(Content entity)
        {
            _contentDal.Update(entity);
        }

        public List<Content> GetAll()
        {
            return _contentDal.List();
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.ContentId ==id);
        }
    }
}
