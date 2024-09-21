using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.IRopesitory
{
    public interface IPersonRepository
    {
        public List<Person> GetAll();

        public Person GetPersonById(int id);

        public void Create(Person person);
        public void Update(Person person);
        public void Delete(int id);
    }
}
