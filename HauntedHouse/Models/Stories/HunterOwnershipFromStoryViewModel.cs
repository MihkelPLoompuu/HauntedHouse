using HauntedHouse.Core.Dto;

namespace HauntedHouse.Models.Stories
{
    public class HunterOwnershipFromStoryViewModel
    {
        public string PlayerProfileGUID { get; set; }

        public string StoryGUID { get; set;}

        public  HunterOwnershipDto addHunter {  get; set; }
    }
}
