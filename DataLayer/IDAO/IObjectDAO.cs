using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IDAO
{
    public interface IObjectDAO<T>
    {
        public List<T> GetAll();
        public void Create(T obj);
        public void Update(T obj, string id);
        public void Delete(T obj);
        public T GetById(int id);
        public void DeleteAll();

    }
}
