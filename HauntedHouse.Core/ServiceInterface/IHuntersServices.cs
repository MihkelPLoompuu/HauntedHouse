using HauntedHouse.Core.Domain;
using HauntedHouse.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.ServiceInterface
{
    public interface IHuntersServices
    {
        Task<Hunter> DetailsAsync(Guid id);
        Task<Hunter> Create(HunterDto dto);
        Task<Hunter> Update(HunterDto dto);
        Task<Hunter> Delete(Guid id);
    }
}
