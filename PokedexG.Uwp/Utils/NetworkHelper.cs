using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Microsoft.Toolkit.Uwp;

namespace PokedexG.Uwp.Utils
{
    public static class NetworkHelper
    {
        internal static async Task<bool> CheckInternetConnection()
        {
            if (!ConnectionHelper.IsInternetAvailable)
            {
                var dialog = new MessageDialog("Aucune connexion Internet n'est déconnectée. Merci d'essayer à nouveau plus tard.");
                await dialog.ShowAsync();

                return false;
            }

            return true;
        }
    }
}