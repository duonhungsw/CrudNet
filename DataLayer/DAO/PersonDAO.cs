using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAO
{
    public class PersonDAO
    {
        private static PersonDAO instance = new();
        private static readonly object instanceLock = new();
        private PersonDAO() { }
        public static PersonDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new PersonDAO();
                }
                return instance;
            }
        }

        public List<Person> GetAll() { 
            List<Person> list = [];
            try
            {
                using AppDbContext dbContext = new();
                list = [.. dbContext.Person];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public Person GetPersonById(int id)
        {
            try
            {
                using AppDbContext dbContext = new();
                var personFound = dbContext.Person.FirstOrDefault(p => p.Id == id);
                if (personFound != null)
                {
                    return personFound;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Create(Person person) {
            try
            {
                using AppDbContext dbContext = new();
                dbContext.Add(person);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Person person)
        {
            try
            {
                using AppDbContext dbContext = new();
                dbContext.Entry<Person>(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                using AppDbContext dbContext = new();
                var personFound = dbContext.Person.FirstOrDefault(p => p.Id == id);
                if (personFound != null)
                {
                    dbContext.Remove(personFound);
                }
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
