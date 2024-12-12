using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.Domain
{
    public class HunterOwnership
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
        public DateTime OwnershipCreatedAt { get; set; }
        public DateTime OwnershipUpdatedAt { get; set; }
    }
}
