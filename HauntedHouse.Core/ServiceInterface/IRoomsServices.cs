using HauntedHouse.Core.Domain;
using HauntedHouse.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.ServiceInterface
{
    public interface IRoomsServices
    {
        Task<Room> Create(RoomDto dto);
    }
}
