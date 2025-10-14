using System;

namespace LunyScratch
{
	/// <summary>
	/// Modifies a Variable instance using a math operator and an operand (Double or Variable).
	/// Enforces numeric-only semantics for target variable (assign preserves type for Variable operand).
	/// </summary>
	internal sealed class ModifyVariableBlock : IScratchBlock
	{
		private readonly Variable _variable;
		private readonly Double _operand;
		private readonly Variable _operandVar;
		private readonly Boolean _useVarOperand;
		private readonly MathOperator _op;
	
		public ModifyVariableBlock(Variable variable, MathOperator op, Double operand)
		{
			_variable = variable;
			_operand = operand;
			_op = op;
			_useVarOperand = false;
		}
	
		public ModifyVariableBlock(Variable variable, MathOperator op, Variable operand)
		{
			_variable = variable;
			_operandVar = operand;
			_op = op;
			_useVarOperand = true;
		}
	
		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			if (_useVarOperand)
				VariableMath.Apply(_variable, _operandVar, _op);
			else
				VariableMath.Apply(_variable, _operand, _op);
		}
	
		public Boolean IsComplete() => true;
	}
}
