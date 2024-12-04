using HauntedHouse.Core.Domain;

namespace HauntedHouse.Models.Rooms
{
    public class RoomIndexViewModel
    {
        public Guid ID { get; set; }
        public string RoomName { get; set; }
        public RoomType RoomType { get; set; }
        public Guid? BuildingID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
