namespace PokemonAPI.WebService.Models
{
    public partial class ConquestWarriorSpecialties
    {
        public int WarriorId { get; set; }
        public int TypeId { get; set; }
        public int Slot { get; set; }

        public virtual Types Type { get; set; }
        public virtual ConquestWarriors Warrior { get; set; }
    }
}
