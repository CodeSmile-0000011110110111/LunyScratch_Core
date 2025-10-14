using System;

namespace LunyScratch
{
	/// <summary>
	/// Modifies a Variable instance using a math operator and a numeric operand.
	/// Enforces numeric-only semantics for target variable (assign will force numeric).
	/// </summary>
	internal sealed class ModifyVariableBlock : IScratchBlock
	{
		private readonly Variable _variable;
		private readonly Double _operand;
		private readonly MathOperator _op;

		public ModifyVariableBlock(Variable variable, MathOperator op, Double operand)
		{
			_variable = variable;
			_operand = operand;
			_op = op;
		}

		public void Run(IScratchContext context, Double deltaTimeInSeconds) => VariableMath.Apply(_variable, _operand, _op);

		public Boolean IsComplete() => true;
	}
}
