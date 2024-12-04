using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.Domain
{
    public enum RoomType
    {
        Attic,
        Bathroom,
        Living_room,
        Kitchen,
        Garage,
        bedroom,
        basement,
        Library,
        Office,
        Guest_room,
        Gym
    }
    public class Room
    {
        public Guid ID { get; set; }
        public string RoomName { get; set; }
        public RoomType RoomType { get; set; }
        public Guid? BuildingID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
