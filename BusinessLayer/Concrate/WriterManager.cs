﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class WriterManager : IWriterService
    {

        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID==id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }

        public void WriterAdd(Writer witer)
        {
            _writerDal.Insert(witer);

        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }
    }
}
