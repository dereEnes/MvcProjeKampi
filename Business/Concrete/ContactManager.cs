﻿using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager:IContactService
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public List<Contact> GetAll()
        {
            return _contactDal.List();
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(x => x.ContactId == id);
        }

        public void Insert(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
