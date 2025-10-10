// Variable wrapper (weakly typed, like Scratch)

using System;
using System.Collections.Generic;

namespace LunyScratch
{
	// Table (array + dictionary hybrid, like Lua)
	public sealed class Table
	{
		// 1-indexed!
		private readonly List<Variable> _array = new();
		private readonly Dictionary<String, Variable> _dictionary = new();

		// Array operations (1-indexed like Scratch/Lua)
		public void Add(Variable value) => _array.Add(value);

		public Variable Get(Int32 index) => index <= 0 || index > _array.Count ? new Variable(0) : _array[index - 1];

		public void Set(Int32 index, Variable value)
		{
			if (index > 0 && index <= _array.Count)
				_array[index - 1] = value;
		}

		public Int32 Length() => _array.Count;

		// Dictionary operations
		public Variable Get(String key) => String.IsNullOrEmpty(key) && _dictionary.TryGetValue(key, out var v) ? v : default;

		// Lazy initialize: if key doesn't exist, create entry
		public void Set(String key, Variable value)
		{
			if (!String.IsNullOrEmpty(key))
				_dictionary[key] = value;
		}

		public Boolean Has(String key) => String.IsNullOrEmpty(key) == false && _dictionary.ContainsKey(key);

		// Increment a named variable by amount (numeric). Creates the variable if missing. Warns if incompatible.
		public void Increment(String key, Variable amount)
		{
			if (String.IsNullOrEmpty(key))
				return;

			if (!_dictionary.TryGetValue(key, out var current))
				current = new Variable(0.0);

			if (current.IsNumeric)
			{
				current.Increment(amount);
				_dictionary[key] = current;
			}
			else
				GameEngine.Actions.LogWarn($"IncrementVariable: variable '{key}' is not numeric; no change applied.");
		}

		// Change a named variable by delta (Double). If missing, initialize from initialValue. Warn if incompatible.
		public void Change(String key, Variable initialValue, Double delta)
		{
			if (String.IsNullOrEmpty(key))
				return;

			if (!_dictionary.TryGetValue(key, out var current))
			{
				current = initialValue;
				_dictionary[key] = current;
			}

			if (current.Type != ValueType.String)
			{
				current.Increment(delta);
				_dictionary[key] = current;
			}
			else
				GameEngine.Actions.LogWarn($"ChangeVariable: variable '{key}' is a string; cannot change numerically.");
		}

		public override String ToString() => $"Table(arr={_array.Count}, dict={_dictionary.Count})";
	}
}
