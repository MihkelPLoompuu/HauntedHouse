using HauntedHouse.Core.Domain;
using HauntedHouse.Core.Dto;

namespace HauntedHouse.Models.Rooms
{
    public class RoomCreateViewModel
    {
        public Guid ID { get; set; }
        public string RoomName { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomLevel { get; set; }
        public Guid? BuildingID { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        //db
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
