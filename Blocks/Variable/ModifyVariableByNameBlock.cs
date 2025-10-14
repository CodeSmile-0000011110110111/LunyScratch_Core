using System;

namespace LunyScratch
{
	/// <summary>
	/// Modifies a named variable (from the current context's Table) using a math operator and an operand (Double or Variable).
	/// </summary>
	internal sealed class ModifyVariableByNameBlock : IScratchBlock
	{
		private readonly String _name;
		private readonly Double _operand;
		private readonly Variable _operandVar;
		private readonly Boolean _useVarOperand;
		private readonly MathOperator _op;
	
		public ModifyVariableByNameBlock(String name, MathOperator op, Double operand)
		{
			_name = name;
			_operand = operand;
			_op = op;
			_useVarOperand = false;
		}
	
		public ModifyVariableByNameBlock(String name, MathOperator op, Variable operand)
		{
			_name = name;
			_operandVar = operand;
			_op = op;
			_useVarOperand = true;
		}
	
		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			var vars = context?.Runner?.Variables;
			if (_useVarOperand)
				VariableMath.ApplyByName(vars, _name, _operandVar, _op);
			else
				VariableMath.ApplyByName(vars, _name, _operand, _op);
		}
	
		public Boolean IsComplete() => true;
	}
}
