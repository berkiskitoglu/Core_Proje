using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDal _writerMessageDal;

        public WriterMessageManager(IWriterMessageDal writerMessageDal)
        {
            _writerMessageDal = writerMessageDal;
        }

        public List<WriterMessage> GetListReceiverMessage(string p)
        {
             return _writerMessageDal.GetbyFilter(x => x.Receiver == p);
        }

        public List<WriterMessage> GetListSenderMessage(string p)
        {
            return _writerMessageDal.GetbyFilter(x => x.Sender == p);
        }

        public void TAdd(WriterMessage t)
        {
            _writerMessageDal.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
            _writerMessageDal.Delete(t);
        }

        public List<WriterMessage> TGetbyFilter(string p)
        {
            return _writerMessageDal.GetbyFilter(x=>x.Sender == p);
        }

        public List<WriterMessage> TGetbyFilter()
        {
            throw new NotImplementedException();
        }

        public WriterMessage TGetByID(int id)
        {
            return _writerMessageDal.GetByID(id);
        }

        public List<WriterMessage> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterMessage t)
        {
            throw new NotImplementedException();
        }
    }
}
