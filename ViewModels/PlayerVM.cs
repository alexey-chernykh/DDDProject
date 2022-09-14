using Entities;

namespace ViewModels
{
    public class PlayerVM
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Sex { get; set; }
        public string? Country { get; set; }
        public string? HeroType { get; set; }
        public int? Experience { get; set; }
        public PlayerVM(Player player)
        {
            Id = player.Id;
            Name = player.Name;
            Email = player.Email;
            BirthDate = player.BirthDate;
            Sex = player.Sex;
            Country = player.Country;
            HeroType = player.HeroType;
            Experience = player.Experience;
        }
    }
}