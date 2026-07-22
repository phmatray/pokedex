// Équivalent web du SettingsService UWP (Template10 SettingsHelper) : mêmes clés, mêmes
// valeurs par défaut, persisté dans localStorage.
using Microsoft.JSInterop;

namespace PokedexG.Web.Services;

public class SettingsService
{
    private readonly IJSInProcessRuntime _js;

    public SettingsService(IJSInProcessRuntime js) => _js = js;

    public event Action? Changed;

    /// <summary>Pokédex trié par famille d'évolution (sinon par numéro). Défaut UWP : oui.</summary>
    public bool UsePokedexEvolutionFamilies
    {
        get => Read(nameof(UsePokedexEvolutionFamilies), true);
        set => Write(nameof(UsePokedexEvolutionFamilies), value);
    }

    /// <summary>Afficher les méga-évolutions (et primo-résurgences). Défaut UWP : oui.</summary>
    public bool UsePokedexMegaEvolutions
    {
        get => Read(nameof(UsePokedexMegaEvolutions), true);
        set => Write(nameof(UsePokedexMegaEvolutions), value);
    }

    /// <summary>Afficher les formes alternatives. Défaut UWP : oui.</summary>
    public bool UsePokedexAlternatives
    {
        get => Read(nameof(UsePokedexAlternatives), true);
        set => Write(nameof(UsePokedexAlternatives), value);
    }

    /// <summary>true = illustrations de Sugimori, false = Global Link. Défaut UWP : Sugimori.</summary>
    public bool ArtworkStyle
    {
        get => Read(nameof(ArtworkStyle), true);
        set => Write(nameof(ArtworkStyle), value);
    }

    /// <summary>« rubis » (clair, défaut UWP : Light) ou « saphir » (nuit).</summary>
    public string AppTheme
    {
        get => _js.Invoke<string?>("localStorage.getItem", "AppTheme") ?? "rubis";
        set
        {
            _js.InvokeVoid("localStorage.setItem", "AppTheme", value);
            _js.InvokeVoid("pkdx.applyTheme", value);
            Changed?.Invoke();
        }
    }

    public string IllustrationFolder => ArtworkStyle ? "sugimori" : "globallink";

    public string IllustrationPath(string formKey) => $"img/{IllustrationFolder}/{formKey}.jpg";

    public static string IconPath(object key) => $"img/icons/{key}.png";

    private bool Read(string key, bool fallback)
        => _js.Invoke<string?>("localStorage.getItem", key) is { } raw ? raw == "1" : fallback;

    private void Write(string key, bool value)
    {
        _js.InvokeVoid("localStorage.setItem", key, value ? "1" : "0");
        Changed?.Invoke();
    }
}
