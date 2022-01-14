using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Models
{
    /// <summary>
    /// A key-value dictionary. Used to store HTML attributes. This can be serializable unlike a traditional C# Dictionary.
    /// </summary>
    public class Dict
    {
        #region Fields

        public List<string> _keys;
        public List<string> _values;
        public int _length;

        #endregion Fields

        #region Properties

        public int Length
        {
            get => _length;
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Dict()
        {
            _keys = new List<string>();
            _values = new List<string>();
            _length = 0;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        public Dict(Dict toBeCopied)
        {
            _keys = new List<string>(toBeCopied._keys);
            _values = new List<string>(toBeCopied._values);
            _length = toBeCopied.Length;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Get the value associated with this key string. Returns "" if the key was not found.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            key = key.Trim();
            int index = _keys.IndexOf(key);

            if (index >= 0)
            {
                return _values.ElementAt(index);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Return a list of all the keys in this dict.
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeys()
        {
            return new List<string>(_keys);
        }

        /// <summary>
        /// Store a key value pair into the dict. If a key already exists, it's value will be overwritten. Cannot add empty or whitespace strings.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, string value)
        {
            key = key.Trim();
            value = value.Trim();

            // Prevent adding empty strings.
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
            {
                return;
            }

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
                _length++;
            }
        }

        /// <summary>
        /// Returns true if the key is in the dict.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            key = key.Trim();
            return _keys.Contains(key);
        }

        /// <summary>
        /// Remove a key-value from the dict.
        /// </summary>
        public void Remove(string key)
        {
            key = key.Trim();
            int index = _keys.IndexOf(key);
            if (index >= 0)
            {
                // Key exists, remove it.
                _keys.RemoveAt(index);
                _values.RemoveAt(index);
                _length--;
            }
        }

        /// <summary>
        /// Clear every key-value from the dict.
        /// </summary>
        public void Clear()
        {
            _keys.Clear();
            _values.Clear();
            _length = 0;
        }

        #endregion Methods
    }
}
