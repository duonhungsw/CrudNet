using BusinessLayer.Model;
using DataLayer.DAO;
using DataLayer.Repository.IRopesitory;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.HRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Create(Employee employee) => EmployeeDao.Instance.Create(employee);

        public void Delete(int id) => EmployeeDao.Instance.Delete(id);

        public List<Employee> GetAll() => EmployeeDao.Instance.getAll();

        public Employee GetById(int id) => EmployeeDao.Instance.GetEmployeeById(id);

        public Employee login(string name, string email) => EmployeeDao.Instance.Login(name, email);

        public void Update(Employee employee) => EmployeeDao.Instance.Update(employee);
    }
}
