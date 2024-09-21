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
    public class RoomRepository : IRoomRepository
    {
        public void Create(Room room) => RoomDAO.Instance.Create(room);
        public void Delete(int id)  => RoomDAO.Instance.Delete(id);

        public List<Room> GetAll() => RoomDAO.Instance.GetAll();
        public Room? GetRoomById(int id) => RoomDAO.Instance.GetRoomById(id);

        public void Update(Room room) => RoomDAO.Instance.Update(room);
    }
}
