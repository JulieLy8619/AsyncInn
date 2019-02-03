using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class IRoomMgmtServices : IRoomMgmt
    {
        private HotelMgmtDBContext _context { get; }
        public IRoomMgmtServices(HotelMgmtDBContext context)
        {
            _context = context;
        }
        public async Task CreateRoom(Room room)
        {
            _context.RoomTable.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> DeleteRoom(int id)
        {
            Room room = _context.RoomTable.FirstOrDefault(rm => rm.ID == id);
            _context.RoomTable.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.RoomTable.FirstOrDefaultAsync(rm => rm.ID == id);
        }

        public async Task<IEnumerable<Room>> GetRoom()
        {
            return await _context.RoomTable.ToListAsync();
        }

        public async Task<IEnumerable<Room>> SearchRoom(string id)
        {
            var roos = from a in _context.RoomTable
                       select a;

            foreach (Room roo in roos)
            {
                var rAmen = from ra in _context.RoomAmenitiesTable
                           where ra.RoomID == roo.ID
                           select ra;
                roo.RAmenitites = await rAmen.ToListAsync();
            }

            if (!String.IsNullOrEmpty(id))
            {
                roos = roos.Where(n => n.Name.Contains(id));
            }
            return await roos.ToListAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _context.RoomTable.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
