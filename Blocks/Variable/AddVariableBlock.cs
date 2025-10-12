using System;

namespace LunyScratch
{
	// Increments a numeric variable by the provided amount (from Variable's numeric form)
	internal sealed class AddVariableBlock : IScratchBlock
	{
		private readonly string _name;
		private readonly double _increment;

		public AddVariableBlock(String name, double increment)
		{
			_name = name;
			_increment = increment;
		}

		public void Run(IScratchContext context, double deltaTimeInSeconds)
		{
			var variables = context?.Runner?.Variables;
			if (variables != null)
			{
				variables.AddValue(_name, _increment);
			}
		}

		public bool IsComplete() => true;
	}
}
