using HauntedHouse.Core.Domain;

namespace HauntedHouse.Models.Rooms
{
    public class RoomDetailsViewModel
    {
        public Guid ID { get; set; }
        public string RoomName { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomLevel { get; set; }
        public Guid? BuildingID { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<RoomImageViewModel> Image { get; set; } = new();

        //db
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
