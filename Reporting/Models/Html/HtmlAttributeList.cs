using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Models.Html
{
    /// <summary>
    /// A key-value list. Used to store HTML attributes similar to a Dictionary. This can be serializable unlike a traditional C# Dictionary.
    /// </summary>
    public class HtmlAttributeList
    {
        public List<string> _keys;
        public List<string> _values;
        public int Length;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public HtmlAttributeList()
        {
            _keys = new List<string>();
            _values = new List<string>();
            Length = 0;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        public HtmlAttributeList(HtmlAttributeList toBeCopied)
        {
            _keys = toBeCopied._keys;
            _values = toBeCopied._values;
            Length = toBeCopied.Length;
        }

        /// <summary>
        /// Get the value associated with this key string. Returns "" if the key was not found.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            int index = _keys.IndexOf(key);
            // Key was found. Return its value.
            if (index >= 0)
            {
                return _values.ElementAt(index);
            }
            // No key found.
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Store a key value pair into the list. If a key already exists, it's value will be overwritten.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, string value)
        {
            int index = _keys.IndexOf(key);
            // Key exists, update the current value.
            if (index >= 0)
            {
                _values.RemoveAt(index);
                _values.Insert(index, value);
            }
            // This key doesn't exist, add the new key-value pair.
            else
            {
                _keys.Add(key);
                _values.Add(value);
                Length++;
            }
        }

        /// <summary>
        /// Parse the key-values into an html attribute string.
        /// </summary>
        public string ParseAttributes()
        {
            string res = "";
            foreach (string attr in _keys)
            {
                string value = Get(attr);
                res += $" {attr}=\"{value}\"";
            }
            return res;
        }

        /// <summary>
        /// Returns true if the key is in the list.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            return _keys.Contains(key);
        }

        /// <summary>
        /// Remove a key-value from the list.
        /// </summary>
        public void Remove(string key)
        {
            int index = _keys.IndexOf(key);
            // Key exists, remove it.
            if (index >= 0)
            {
                _keys.RemoveAt(index);
                _values.RemoveAt(index);
                Length--;
            }
        }

        /// <summary>
        /// Clear every key-value from the list.
        /// </summary>
        public void Clear()
        {
            _keys.Clear();
            _values.Clear();
            Length = 0;
        }
    }
}
