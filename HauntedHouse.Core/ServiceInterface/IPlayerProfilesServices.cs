using HauntedHouse.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.ServiceInterface
{
    public interface IPlayerProfilesServices
    {
        Task<PlayerProfile> Create(string useridfor);
        Task<PlayerProfile> DetailsAsync(Guid id);
    }
}
