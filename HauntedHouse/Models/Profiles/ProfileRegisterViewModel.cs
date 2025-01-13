using HauntedHouse.Core.Domain;

namespace HauntedHouse.Models.Profiles
{
    public class ProfileRegisterViewModel
    {
        public Guid ID { get; set; }
        public string ApplicationUserID { get; set; } 
        public string ScreenName { get; set; }
        public int HunterCredits { get; set; }
        public int Victories { get; set; }
        public int MyProperty { get; set; }
        public string? MyBuilding { get; set; } 
        public ProfileStatus CurrentStatus { get; set; }
        public bool ProfileType { get; set; } 
    }
}
