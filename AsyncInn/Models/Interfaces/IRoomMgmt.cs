using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomMgmt
    {
        Task CreateRoom(Room room);
        Task<Room> GetRoom(int id);
        Task<IEnumerable<Room>> GetRoom();
        Task<IEnumerable<Room>> SearchRoom(string id);
        Task UpdateRoom(Room room);
        Task<Room> DeleteRoom(int id);
    }
}
