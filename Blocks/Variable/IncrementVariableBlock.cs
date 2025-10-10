using System;

namespace LunyScratch
{
	// Increments a numeric variable by the provided amount (from Variable's numeric form)
	internal sealed class IncrementVariableBlock : IScratchBlock
	{
		private readonly string _name;
		private readonly Variable _increment;

		public IncrementVariableBlock(String name, Variable increment)
		{
			_name = name;
			_increment = increment;
		}

		public void Run(IScratchContext context, double deltaTimeInSeconds)
		{
			var table = context?.Runner?.Variables;
			if (table != null)
				table.Increment(_name, _increment);
		}

		public bool IsComplete() => true;
	}
}
