using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Wlx2Explorer
{
    class InitializationFile
    {
        private string _fileName = null;
        private Encoding _fileEncoding = null;
        private IDictionary<string, IDictionary<string, string>> _content = null;

        public InitializationFile(string file) : this(file, Encoding.Default)
        {
        }

        public InitializationFile(string file, Encoding encoding)
        {
            _fileName = file;
            _fileEncoding = encoding;
        }

        public IDictionary<string, string> GetSection(string sectionName)
        {
            var section = _content.ContainsKey(sectionName) ? _content[sectionName] : null;
            return section;
        }

        public string GetValue(string sectionName, string keyName)
        {
            var value = _content.ContainsKey(sectionName) && _content[sectionName].ContainsKey(keyName) ? _content[sectionName][keyName] : null;
            return value;
        }

        public void SetSection(string sectionName, IDictionary<string, string> items)
        {
            _content[sectionName] = items;
        }

        public void SetValue(string sectionName, string keyName, string value)
        {
            if (!_content.ContainsKey(sectionName))
            {
                _content[sectionName] = new Dictionary<string, string>();
            }
            _content[sectionName][keyName] = value;
        }

        public void LoadFile()
        {
            LoadFile(_fileName, _fileEncoding);
        }

        public void LoadFile(string fileName)
        {
            LoadFile(fileName, _fileEncoding);
        }

        public void LoadFile(string fileName, Encoding fileEncoding)
        {
            _content = Load(fileName, fileEncoding);
        }

        public void SaveFile()
        {
            SaveFile(_fileName, _fileEncoding);
        }

        public void SaveFile(string fileName)
        {
            SaveFile(fileName, _fileEncoding);
        }

        public void SaveFile(string fileName, Encoding fileEncoding)
        {
            using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
            using (var writer = new StreamWriter(file, fileEncoding))
            {
                writer.Write(ToString());
            }
        }

        public override string ToString()
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

        private Dictionary<string, IDictionary<string, string>> Load(string fileName, Encoding fileEncoding)
        {
            var content = new Dictionary<string, IDictionary<string, string>>();
            using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(file, _fileEncoding))
            {
                string line = null;
                string section = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length == 0) continue;
                    if (line.StartsWith(";")) continue;
                    if (line.Length > 2 && line[0] == '[' && line[line.Length - 1] == ']')
                    {
                        section = line.Substring(1, line.Length - 2);
                        if (content.ContainsKey(section)) continue;
                        content[section] = new Dictionary<string, string>();
                    }
                    else
                    {
                        if (section == null) continue;
                        var pair = line.Split('=');
                        if (pair.Length < 2) continue;
                        var keyValue = new KeyValuePair<string, string>(pair[0], pair[1]);
                        if (content[section].Contains(keyValue)) continue;
                        content[section].Add(keyValue);
                    }
                }
            }
            return content;
        }
    }
}
