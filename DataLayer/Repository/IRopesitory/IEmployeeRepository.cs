using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.IRopesitory
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAll();
        public void Create(Employee employee);
        public void Update(Employee employee);
        public void Delete(int id);

        public Employee GetById(int id);

        public Employee login(string name, string email);
    }
}
