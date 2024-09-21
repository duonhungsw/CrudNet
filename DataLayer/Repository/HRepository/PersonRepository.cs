using BusinessLayer.Model;
using DataLayer.DAO;
using DataLayer.Repository.IRopesitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.HRepository
{
    public class PersonRepository : IPersonRepository
    {
        public void Create(Person person) => PersonDAO.Instance.Create(person);

        public void Delete(int id) => PersonDAO.Instance.Delete(id);

        public List<Person> GetAll() => PersonDAO.Instance.GetAll();

        public Person GetPersonById(int id) => PersonDAO.Instance.GetPersonById(id);
        public void Update(Person person) => PersonDAO.Instance.Update(person);
    }
}
