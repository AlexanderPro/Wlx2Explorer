using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wlx2Explorer.Configuration
{
    class PluginInfo
    {
        public string Path { get; set; }

        public IList<string> Extensions { get; set; }

        public PluginInfo() : this("", new List<string>())
        {
        }

        public PluginInfo(string path, IList<string> extensions)
        {
            Path = path;
            Extensions = extensions;
        }
    }
}
