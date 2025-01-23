using HauntedHouse.Core.Domain;
using HauntedHouse.Core.Dto;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.ApplicationServices.Services
{
    public class BuildingsServices : IBuildingsServices
    {
        private readonly HauntedHouseContext _context;
        private readonly IFileServices _fileServices;

        public BuildingsServices(HauntedHouseContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<Building> DetailsAsync(Guid id)
        {
            var result = await _context.Buildings
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
        public async Task<Building> Create(BuildingDto dto)
        {
            Building room = new Building();

            room.ID = Guid.NewGuid();

            //set by user
            room.BuildingName = dto.BuildingName;
            room.BuildingType = dto.BuildingType;

            //set for db
            room.CreatedAt = DateTime.Now;
            room.UpdatedAt = DateTime.Now;

            await _context.Buildings.AddAsync(room);
            await _context.SaveChangesAsync();

            return room;
        }
    }
}
