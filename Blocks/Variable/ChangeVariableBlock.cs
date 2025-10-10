using System;

namespace LunyScratch
{
	// Changes a numeric variable by a constant delta
	internal sealed class ChangeVariableBlock : IScratchBlock
	{
		private readonly string _name;
		private readonly Variable _initialValue;
		private readonly double _delta;

		public ChangeVariableBlock(String name, Variable initialValue, Double delta)
		{
			_name = name;
			_initialValue = initialValue;
			_delta = delta;
		}

		public void Run(IScratchContext context, double deltaTimeInSeconds)
		{
			var table = context?.Runner?.Variables;
			if (table == null || string.IsNullOrEmpty(_name)) return;

			// Delegate creation/type checks to Table
			table.Change(_name, _initialValue, _delta);
		}

		public bool IsComplete() => true;
	}
}
