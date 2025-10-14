using System;

namespace LunyScratch
{
	/// <summary>
	/// Condition block that compares a Variable (or a named variable in Table) to a numeric value
	/// using the specified ComparisonOperator. Non-numeric variables cause a warning and evaluate to false.
	/// </summary>
	internal sealed class IsVariableConditionBlock : ConditionBlock
	{
		private readonly Variable _variable;
		private readonly String _variableName;
		private readonly Double _value;
		private readonly ComparisonOperator _op;

		// Compare a provided Variable instance
		public IsVariableConditionBlock(Variable variable, Double value, ComparisonOperator op)
			: base(ctx =>
			{
				if (variable == null)
					return false;

				if (!variable.IsNumber && !variable.IsNull)
				{
					// Non-numeric: warn and return false
					var name = variable.Name ?? "(unnamed)";
					GameEngine.Actions.LogWarn($"IsVariable: variable '{name}' is not numeric; comparison skipped.");
					return false;
				}

				var lhs = variable.Number;
				return VariableMath.Compare(lhs, op, value);
			})
		{
			_variable = variable;
			_value = value;
			_op = op;
		}

		// Compare a named variable via context table
		public IsVariableConditionBlock(String variableName, Double value, ComparisonOperator op)
			: base(ctx =>
			{
				if (ctx == null || ctx.Runner == null)
					return false;

				var vars = ctx.Runner.Variables;
				if (vars == null || String.IsNullOrEmpty(variableName))
					return false;

				var v = vars.Get(variableName);
				if (v == null)
					return false;

				if (!v.IsNumber && !v.IsNull)
				{
					GameEngine.Actions.LogWarn($"IsVariable('{variableName}'): variable is not numeric; comparison skipped.");
					return false;
				}

				var lhs = v.Number;
				return VariableMath.Compare(lhs, op, value);
			})
		{
			_variableName = variableName;
			_value = value;
			_op = op;
		}
	}
}
