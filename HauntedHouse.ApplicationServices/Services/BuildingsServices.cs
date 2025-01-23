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
        public async Task<Building> Create(BuildingDto dto, List<Room> rooms)
        {
            Building newBuilding = new();

            newBuilding.ID = Guid.NewGuid();

            newBuilding.BuildingName = dto.BuildingName;

            newBuilding.CreatedAt = DateTime.Now;
            newBuilding.UpdatedAt = DateTime.Now;
            newBuilding.RoomIDs = RoomToID(roomsInBuilding);

            await _context.SolarSystems.AddAsync(newBuilding);
            await _context.SaveChangesAsync();

            foreach (var planet in roomsInBuilding)
            {
                _context.Rooms.Attach(planet);
                planet.BuildingId = newBuilding.ID.ToString();
                planet.ModifiedAt = DateTime.Now;

                _context.Entry(planet).Property(p => p.SolarSystemID).IsModified = true;
                _context.Entry(planet).Property(p => p.ModifiedAt).IsModified = true;



                await _context.SaveChangesAsync();
            }

            return newBuilding;
        }
    }
}
