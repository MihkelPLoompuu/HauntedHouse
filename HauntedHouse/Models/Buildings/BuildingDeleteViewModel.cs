using HauntedHouse.Core.Domain;
using HauntedHouse.Models.Rooms;

namespace HauntedHouse.Models.Buildings
{
    public class BuildingDeleteViewModel
    {
        public Guid? ID { get; set; }
        public string BuildingName { get; set; }
        public BuildingType BuildingType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Guid>? RoomsIDs { get; set; } = new List<Guid>();
        public List<RoomIndexViewModel>? Rooms { get; set; } = new();
    }
}
