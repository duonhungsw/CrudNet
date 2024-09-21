using BusinessLayer.Model;
using DataLayer.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAO
{
    public class EmployeeDao 
    {
        private static EmployeeDao? instance;
        private static readonly object instanceLock = new();
        private EmployeeDao() { }

        public static EmployeeDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new EmployeeDao();

                }
                return instance;
            }
        }
        public List<Employee> getAll()
        {
            List<Employee> employees = [];
            
            try
            {
                using AppDbContext dbContext = new();
                employees = [.. dbContext.Employee];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employees;
        }

        public void Create(Employee employee)
        {
            using AppDbContext dbContext = new();
            try
            {
                dbContext.Employee.Add(employee);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Employee employee)
        {
            using AppDbContext appDbContext = new();
            try
            {
                
                appDbContext.Entry<Employee>(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            using AppDbContext dbContext = new AppDbContext();
            try
            {
                var employeeid = dbContext.Employee.Find(id);
                dbContext.Employee.Remove(employeeid);
                dbContext.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        public Employee? GetEmployeeById(int id)
        {
            try
            {
                using AppDbContext appDbContext = new();
                var userFound = appDbContext.Employee.FirstOrDefault(u => u.Id == id);
                if (userFound != null)
                {
                    return userFound;
                }
                return null;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

        }

        public Employee? Login(string username, string email)
        {
            try
            {
                using AppDbContext dbContext = new();
                var employee = dbContext.Employee.FirstOrDefault(e => e.name == username && e.email == email);
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    
}
