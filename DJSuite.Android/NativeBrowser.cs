using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DJSuite.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(NativeBrowser))]
namespace DJSuite.Droid
{
    public class NativeBrowser : INativeBrowser
    {
        async Task<string> INativeBrowser.LaunchBrowserAsync(string url)
        {
            var browser = new ChromeCustomTabsWebView((Activity)MainActivity.Instance);
            return await browser.InvokeAsync(url);
        }
    }
}