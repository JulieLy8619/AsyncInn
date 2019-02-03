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

        /// <summary>
        /// makes the connection with the DB
        /// </summary>
        public IRoomMgmtServices(HotelMgmtDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// adds a room to the db room table
        /// </summary>
        /// <param name="room">the room to add</param>
        /// <returns>the rows in the room table</returns>

        public async Task CreateRoom(Room room)
        {
            _context.RoomTable.Add(room);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// deletes a room from the DB
        /// </summary>
        /// <param name="id">which room</param>
        /// <returns>the rows in the room table</returns>
        public async Task<Room> DeleteRoom(int id)
        {
            Room room = _context.RoomTable.FirstOrDefault(rm => rm.ID == id);
            _context.RoomTable.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }

        /// <summary>
        /// gets the row for a specific room from the DB
        /// </summary>
        /// <param name="id">which room</param>
        /// <returns>the room's row</returns>
        public async Task<Room> GetRoom(int id)
        {
            return await _context.RoomTable.FirstOrDefaultAsync(rm => rm.ID == id);
        }

        /// <summary>
        /// gets all the rows for the rooms
        /// </summary>
        /// <returns>a list of the rooms</returns>
        public async Task<IEnumerable<Room>> GetRoom()
        {
            return await _context.RoomTable.ToListAsync();
        }

        /// <summary>
        /// queires the DB for all the rooms, and then filters it further based on the param
        /// </summary>
        /// <param name="id">keyword in the room name you would like to filter room list by </param>
        /// <returns>a list of rooms</returns>
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

        /// <summary>
        /// updates the details of a room
        /// </summary>
        /// <param name="room">which room</param>
        /// <returns>the rooms</returns>
        public async Task UpdateRoom(Room room)
        {
            _context.RoomTable.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
