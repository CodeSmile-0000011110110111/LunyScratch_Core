using System;

namespace LunyScratch
{
	// Implements setting a variable by name
	internal sealed class SetVariableBlock : IScratchBlock
	{
		private readonly string _name;
		private readonly Variable _value;

		public SetVariableBlock(String name, Variable value)
		{
			_name = name;
			_value = value;
		}

		public void Run(IScratchContext context, double deltaTimeInSeconds)
		{
			var table = context?.Runner?.Variables;
			if (table == null || string.IsNullOrEmpty(_name)) return;

			// Set always assigns and changes type accordingly
			table.Set(_name, _value);
		}

		public bool IsComplete() => true;
	}
}
