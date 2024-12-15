using HauntedHouse.Core.Domain;
using HauntedHouse.Models.Hunters;

namespace HauntedHouse.Models.Rooms
{
    public class RoomIndexViewModel
    {
        public Guid ID { get; set; }
        public string RoomName { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomLevel { get; set; }
        public Guid? BuildingID { get; set; }
        public List<RoomImageViewModel> Image { get; set; } = new List<RoomImageViewModel>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
