using HauntedHouse.Core.Domain;
using HauntedHouse.Core.Dto;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.ApplicationServices.Services
{
    public class RoomsServices : IRoomsServices
    {
        private readonly HauntedHouseContext _context;
        private readonly IFileServices _fileServices;

        public RoomsServices(HauntedHouseContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<Room> DetailsAsync(Guid id)
        {
            var result = await _context.Rooms
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
        public async Task<Room> Create(RoomDto dto)
        {
            Room room = new Room();

            room.ID = Guid.NewGuid();

            //set by user
            room.RoomName = dto.RoomName;
            room.RoomType = dto.RoomType;

            //set for db
            room.CreatedAt = DateTime.Now;
            room.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, room);
            }

            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();

            return room;
        }
        public async Task<Room> Update(RoomDto dto)
        {
            Room room = new Room();

            // set by service
            room.ID = dto.ID;
            room.BuildingID = dto.BuildingID;

            //set by user
            room.RoomName = dto.RoomName;
            room.RoomType = dto.RoomType;

            //set for db
            room.CreatedAt = dto.CreatedAt;
            room.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, room);
            }
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();

            return room;
        }
        public async Task<Room> Delete(Guid id)
        {
            var result = await _context.Rooms
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.Rooms.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}


