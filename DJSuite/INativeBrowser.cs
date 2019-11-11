using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DJSuite
{   
    public interface INativeBrowser
    {
        Task<string> LaunchBrowserAsync(string url);
    }
    
}
