using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.Dto
{
    public class HunterOwnershipDto : HunterDto
    {
        public Guid OwnershipID { get; set; }
        public int HunterHealth { get; set; }
        public int HunterXP { get; set; }
        public int HunterXPNextLevel { get; set; }
        public int HunterLevel { get; set; }
        public HunterStatus HunterStatus { get; set; }
        public int PrimaryAttackPower { get; set; }
        public int SecondaryAttackPower { get; set; }
        public int SpecialAttackPower { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        public DateTime OwnershipCreatedAt { get; set; }
        public DateTime OwnershipUpdatedAt { get; set; }    
    }
}
