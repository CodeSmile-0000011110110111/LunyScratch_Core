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
		public Variable this[String variableName] { get => Get(variableName); set => Set(variableName, value); }
		public Variable this[Int32 index] { get => Get(index); set => Set(index, value); }

		public Int32 ArrayLength() => _array.Count;
		public Int32 ValueCount() => _array.Count + _dictionary.Count;

		public Variable Get(Int32 index) => index > 1 && index <= _array.Count ? _array[index - 1] : default;

		public Variable Set(Int32 index, Variable value)
		{
			if (index > 0 && index <= _array.Count)
				_array[index - 1] = value;
			return value;
		}

		// Dictionary operations
		public Variable Get(String variableName)
		{
			return !String.IsNullOrEmpty(variableName) && _dictionary.TryGetValue(variableName, out var v) ? v : CreateVariable(variableName);
		}

		private Variable CreateVariable(String variableName)
		{
			var variable = new Variable(0);
			variable.Name = variableName;
			_dictionary[variableName] = variable;
			return variable;
		}

		// Lazy initialize: if key doesn't exist, create entry
		public Variable Set(String variableName, Variable value)
		{
			if (String.IsNullOrEmpty(variableName))
				return null;

			if (_dictionary.TryGetValue(variableName, out var existing) && existing != null)
			{
				// Ensure name is set and consistent
				existing.Name = variableName;
				// Mutate in place to preserve subscriptions and raise change events
				switch (value?.ValueType)
				{
					case ValueType.Boolean:
						existing.Set(value.AsBoolean());
						break;
					case ValueType.Number:
						existing.Set(value.AsNumber());
						break;
					case ValueType.String:
						existing.Set(value.AsString());
						break;
				}
				return existing;
			}
			// New entry: ensure we store a non-null Variable instance
			var stored = value ?? new Variable(0.0);
			stored.Name = variableName;
			_dictionary[variableName] = stored;
			return stored;
		}

		public Boolean Has(String key) => String.IsNullOrEmpty(key) == false && _dictionary.ContainsKey(key);

		// Increment a named variable by amount (numeric). Creates the variable if missing. Warns if incompatible.
		public void AddValue(String variableName, Variable amount)
		{
			if (String.IsNullOrEmpty(variableName))
				return;

			if (!_dictionary.TryGetValue(variableName, out var current))
				current = Set(variableName, new Variable(0.0));

			if (current.IsNumber)
				current.Add(amount);
			else
				GameEngine.Actions.LogWarn($"IncrementVariable: variable '{variableName}' is not numeric; no change applied.");
		}
		public void SubtractValue(String variableName, Variable amount)
		{
			AddValue(variableName, -amount);
		}

		public override String ToString() => $"Table(arr={_array.Count}, dict={_dictionary.Count})";
	}
}
