using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Core.Domain
{
    public enum ProfileStatus
    {
        Active, Abandoned, Deactivated, Locked, Banned, ManualReviewNecessary
    }
    public class PlayerProfile
    {
        public Guid ID { get; set; }
        public string ApplicationUserID { get; set; }
        public string ScreenName { get; set; }
        public int HunterCredits { get; set; }
        public int Victories { get; set; }
        public int MyProperty { get; set; }
        public string? MyBuildings { get; set; }
        public ProfileStatus CurrentStatus { get; set; }
        public bool ProfileType { get; set; }
        public DateTime ProfileCreatedAt { get; set; }
        public DateTime ProfileModifiedAt { get; set; }
        public DateTime ProfileAttributedToAnAccountUserAt { get; set; }
        public DateTime ProfileStatusLastChangedAt { get; set; }
    }
}
