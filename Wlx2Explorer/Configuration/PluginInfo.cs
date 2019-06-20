using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wlx2Explorer.Configuration
{
    class PluginInfo
    {
        public String Path { get; set; }

        public IList<String> Extensions { get; set; }

        public PluginInfo() : this("", new List<String>())
        {
        }

        public PluginInfo(String path, IList<String> extensions)
        {
            Path = path;
            Extensions = extensions;
        }
    }
}
