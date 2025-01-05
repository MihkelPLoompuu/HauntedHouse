using HauntedHouse.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.Dto
{
    public class BuildingDto
    {
        public Guid ID { get; set; }
        public string BuildingName { get; set; }
        public BuildingType BuildingType { get; set; }

        public List<Guid> RoomIDs { get; set; } = new List<Guid>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Room>? Rooms { get; set; } = new();
    }
}
