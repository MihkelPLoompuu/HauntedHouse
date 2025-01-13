using HauntedHouse.Core.Domain;
using HauntedHouse.Core.Dto;
using HauntedHouse.Models.Hunters;

namespace HauntedHouse.Models.Rooms
{
    public class RoomCreateViewModel
    {
        public Guid ID { get; set; }
        public string RoomName { get; set; }
        public RoomType RoomType { get; set; }
        public Guid? BuildingID { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<RoomImageViewModel> Image { get; set; } = new List<RoomImageViewModel>();

        //db
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
