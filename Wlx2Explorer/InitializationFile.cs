using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Wlx2Explorer
{
    class InitializationFile
    {
        private String _fileName = null;
        private Encoding _fileEncoding = null;
        private IDictionary<String, IDictionary<String, String>> _content = null;

        public InitializationFile(String file) : this(file, Encoding.Default)
        {
        }

        public InitializationFile(String file, Encoding encoding)
        {
            _fileName = file;
            _fileEncoding = encoding;
        }

        public IDictionary<String, String> GetSection(String sectionName)
        {
            var section = _content.ContainsKey(sectionName) ? _content[sectionName] : null;
            return section;
        }

        public String GetValue(String sectionName, String keyName)
        {
            var value = _content.ContainsKey(sectionName) && _content[sectionName].ContainsKey(keyName) ? _content[sectionName][keyName] : null;
            return value;
        }

        public void SetSection(String sectionName, IDictionary<String, String> items)
        {
            _content[sectionName] = items;
        }

        public void SetValue(String sectionName, String keyName, String value)
        {
            if (!_content.ContainsKey(sectionName))
            {
                _content[sectionName] = new Dictionary<String, String>();
            }
            _content[sectionName][keyName] = value;
        }

        public void LoadFile()
        {
            LoadFile(_fileName, _fileEncoding);
        }

        public void LoadFile(String fileName)
        {
            LoadFile(fileName, _fileEncoding);
        }

        public void LoadFile(String fileName, Encoding fileEncoding)
        {
            _content = Load(fileName, fileEncoding);
        }

        public void SaveFile()
        {
            SaveFile(_fileName, _fileEncoding);
        }

        public void SaveFile(String fileName)
        {
            SaveFile(fileName, _fileEncoding);
        }

        public void SaveFile(String fileName, Encoding fileEncoding)
        {
            using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
            using (var writer = new StreamWriter(file, fileEncoding))
            {
                writer.Write(ToString());
            }
        }

        public override String ToString()
        {
            var content = new StringBuilder();
            foreach (var pair in _content)
            {
                content.AppendFormat("[{0}]{1}", pair.Key, Environment.NewLine);
                foreach (var pairInner in pair.Value)
                {
                    content.AppendFormat("{0}={1}{2}", pairInner.Key, pairInner.Value, Environment.NewLine);
                }
                content.AppendLine();
            }
            return content.ToString();
        }

        private Dictionary<String, IDictionary<String, String>> Load(String fileName, Encoding fileEncoding)
        {
            var content = new Dictionary<String, IDictionary<String, String>>();
            using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(file, _fileEncoding))
            {
                String line = null;
                String section = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length == 0) continue;
                    if (line.StartsWith(";")) continue;
                    if (line.Length > 2 && line[0] == '[' && line[line.Length - 1] == ']')
                    {
                        section = line.Substring(1, line.Length - 2);
                        if (content.ContainsKey(section)) continue;
                        content[section] = new Dictionary<String, String>();
                    }
                    else
                    {
                        if (section == null) continue;
                        var pair = line.Split('=');
                        if (pair.Length < 2) continue;
                        var keyValue = new KeyValuePair<String, String>(pair[0], pair[1]);
                        if (content[section].Contains(keyValue)) continue;
                        content[section].Add(keyValue);
                    }
                }
            }
            return content;
        }
    }
}
