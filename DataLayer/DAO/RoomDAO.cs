using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance;
        private static readonly object instanceLock = new();
        private RoomDAO() { }

        public static RoomDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new RoomDAO();
                }
                return instance;
            }
        }
        public List<Room> GetAll()
        {
            List<Room> list = [];
           
            try
            {
                using AppDbContext appDbContext = new AppDbContext();
                list = [.. appDbContext.Room];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }


        public Room? GetRoomById(int id) 
        {

            try
            {
                using AppDbContext appDbContext = new AppDbContext();
                var roomFound = appDbContext.Room.FirstOrDefault(u => u.Id == id);
                if (roomFound != null)
                {
                    return roomFound;
                }
                return null;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
           
        }

        public void Create(Room room)
        {
            using AppDbContext appDbContext = new AppDbContext();
            try
            {
                
                appDbContext.Room.Add(room);
                appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Room room)
        {
            
            try
            {
                using AppDbContext appDbContext = new();
                appDbContext.Entry<Room>(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                appDbContext.SaveChanges();
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
                using AppDbContext appDbContext = new();
                var RoomFound = appDbContext.Room.Find(id);
                appDbContext.Remove(RoomFound);
                appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
