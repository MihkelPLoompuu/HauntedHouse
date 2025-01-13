using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.Domain
{
    public enum BuildingType
    {
        Warehouse,
        Skyscraper,
        Ordinary_house,
        Company_building
    }
    public class Building
    {
        public Guid ID { get; set; }
        public string BuildingName { get; set; }
        public BuildingType BuildingType { get; set; }

        public List<Guid> RoomIDs { get; set; } = new List<Guid>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
