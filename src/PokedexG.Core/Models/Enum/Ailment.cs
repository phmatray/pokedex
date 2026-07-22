using Microsoft.Toolkit.Uwp.Services.Core;

namespace PokedexG.Uwp.Models.Enum
{
    public enum Ailment
    {
        [StringValue("????")] Unknown = -1,
        [StringValue("Aucun")] None = 0,
        [StringValue("Paralysie")] Paralysis = 1,
        [StringValue("Sommeil")] Sleep = 2,
        [StringValue("Gel")] Freeze = 3,
        [StringValue("Brûlure")] Burn = 4,
        [StringValue("Empoisonnement")] Poison = 5,
        [StringValue("Confusion")] Confusion = 6,
        [StringValue("Attraction")] Infatuation = 7,
        [StringValue("Piège")] Trap = 8,
        [StringValue("Cauchemar")] Nightmare = 9,
        [StringValue("Tourmente")] Torment = 12,
        [StringValue("Entrave")] Disable = 13,
        [StringValue("Bâillement")] Yawn = 14,
        [StringValue("Anti-Soin")] HealBlock = 15,
        [StringValue("Aucune immunité aux types")] NoTypeImmunity = 17,
        [StringValue("Vampigraine")] LeechSeed = 18,
        [StringValue("Embargo")] Embargo = 19,
        [StringValue("Requiem")] PerishSong = 20,
        [StringValue("Racines")] Ingrain = 21
    }
}