using Windows.Networking.Connectivity;
using Windows.UI.Xaml.Controls;

namespace CryproApp.Core.Helpers
{
    public class InternetChecker
    {

        public static bool IsInternetAvailable()
        {
            var info = NetworkInformation.GetInternetConnectionProfile();
            if (info != null && info.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
            {
                return true;
            }
            return false;
        }

        public static ContentDialog DisplayNoInternet(ContentDialog noWifiDialog)
        {
            noWifiDialog.Title = "No Internet Connection";
            noWifiDialog.PrimaryButtonText = "Try Again";
            noWifiDialog.IsPrimaryButtonEnabled = true;
            noWifiDialog.CloseButtonText = "OK";

            return noWifiDialog;
        }
    }
}
