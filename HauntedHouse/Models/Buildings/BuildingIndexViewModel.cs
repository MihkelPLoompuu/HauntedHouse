using HauntedHouse.Core.Domain;

namespace HauntedHouse.Models.Buildings
{
    public class BuildingIndexViewModel
    {
        public Guid ID { get; set; }
        public string BuildingName { get; set; }
        public BuildingType BuildingType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
