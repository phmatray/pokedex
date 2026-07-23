namespace PokedexG.Uwp.Models
{
    public class TypeLite
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}