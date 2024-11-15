using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.Domain
{
    public enum HunterStatus
    {
        Dead, Alive
    }
    public class Hunter
    {
        public Guid ID { get; set; }
        public string HunterName { get; set; }
        public int HunterHealth { get; set; }
        public int HunterXP { get; set; }
        public int HunterXPNextLevel { get; set; }
        public int HunterLevel { get; set; }
        public HunterStatus HunterStatus { get; set; }
        public int PrimaryAttackPower { get; set; }
        public string PrimaryAttackName { get; set; }
        public int SecondaryAttackPower { get; set; }
        public string SecondaryAttackName { get; set; }
        public int SpecialAttackPower { get; set; }
        public string SpecialAttackName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
