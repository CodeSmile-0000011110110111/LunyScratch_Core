using System;

namespace LunyScratch
{
	/// <summary>
	/// Modifies a named variable (from the current context's Table) using a math operator and a numeric operand.
	/// </summary>
	internal sealed class ModifyVariableByNameBlock : IScratchBlock
	{
		private readonly String _name;
		private readonly Double _operand;
		private readonly MathOperator _op;

		public ModifyVariableByNameBlock(String name, MathOperator op, Double operand)
		{
			_name = name;
			_operand = operand;
			_op = op;
		}

		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			var vars = context?.Runner?.Variables;
			VariableMath.ApplyByName(vars, _name, _operand, _op);
		}

		public Boolean IsComplete() => true;
	}
}
