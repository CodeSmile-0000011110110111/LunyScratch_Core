using System;

namespace LunyScratch
{
	internal sealed class SubtractVariableBlock : IScratchBlock
	{
		private readonly string _name;
		private readonly double _decrement;

		public SubtractVariableBlock(String name, double decrement)
		{
			_name = name;
			_decrement = decrement;
		}

		public void Run(IScratchContext context, double deltaTimeInSeconds)
		{
			var variables = context?.Runner?.Variables;
			if (variables != null)
			{
				var variable = variables.Get(_name);
				variable.Subtract(_decrement);
			}
		}

		public bool IsComplete() => true;
	}
}
