using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.IRopesitory
{
    public interface IRoomRepository
    {
        public List<Room> GetAll();

        public Room GetRoomById(int id);

        public void Create (Room room);

        public void Update (Room room);
        public void Delete (int id);


    }
}
