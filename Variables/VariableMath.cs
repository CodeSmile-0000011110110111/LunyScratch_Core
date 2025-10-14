using System;

namespace LunyScratch
{
	internal static class VariableMath
	{
		internal static void Apply(Variable target, Double operand, MathOperator op)
		{
			if (target == null)
				return;

			if (op == MathOperator.Assign)
			{
				target.Set(operand);
				return;
			}

			if (!target.IsNumber && !target.IsNull)
			{
				GameEngine.Actions.LogWarn($"ModifyVariable: variable '{target.Name ?? "(unnamed)"}' is not numeric; no change applied.");
				return;
			}

			var current = target.Number;
			Double result;

			switch (op)
			{
				case MathOperator.Add:
					result = current + operand;
					break;
				case MathOperator.Subtract:
					result = current - operand;
					break;
				case MathOperator.Multiply:
					result = current * operand;
					break;
				case MathOperator.Divide:
					if (Math.Abs(operand) <= 1e-12)
					{
						GameEngine.Actions.LogWarn("ModifyVariable: divide by zero; no change applied.");
						return;
					}
					result = current / operand;
					break;
				case MathOperator.Modulo:
					if (Math.Abs(operand) <= 1e-12)
					{
						GameEngine.Actions.LogWarn("ModifyVariable: modulo by zero; no change applied.");
						return;
					}
					result = current % operand;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(op), op.ToString());
			}

			target.Set(result);
		}

		internal static void ApplyByName(Table vars, String name, Double operand, MathOperator op)
		{
			if (vars == null || String.IsNullOrEmpty(name))
				return;

			var variable = vars.Get(name);
			if (op == MathOperator.Assign)
			{
				variable.Set(operand);
				return;
			}

			Apply(variable, operand, op);
		}

		public static Boolean Compare(Double operand, ComparisonOperator op, Double value) => op switch
		{
			ComparisonOperator.Less => operand < value,
			ComparisonOperator.LessOrEqual => operand <= value,
			ComparisonOperator.Equal => Math.Abs(operand - value) <= 1e-9,
			ComparisonOperator.NotEqual => Math.Abs(operand - value) > 1e-9,
			ComparisonOperator.Greater => operand > value,
			ComparisonOperator.GreaterOrEqual => operand >= value,
			var _ => false,
		};
	}
}
