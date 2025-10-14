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

		// New overloads to accept Variable as the operand
		internal static void Apply(Variable target, Variable operand, MathOperator op)
		{
			if (operand == null)
			{
				Apply(target, 0.0, op);
				return;
			}

			if (op == MathOperator.Assign)
			{
    switch (operand.ValueType)
				{
					case ValueType.Number:
						target.Set(operand.Number);
						return;
					case ValueType.Boolean:
						target.Set(operand.Boolean);
						return;
					case ValueType.String:
						target.Set(operand.String);
						return;
					default:
						target.Set(0.0);
						return;
				}
			}

			if (!operand.IsNumber)
			{
				GameEngine.Actions.LogWarn("ModifyVariable: operand is not numeric; no change applied.");
				return;
			}

			Apply(target, operand.Number, op);
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

		internal static void ApplyByName(Table vars, String name, Variable operand, MathOperator op)
		{
			if (vars == null || String.IsNullOrEmpty(name))
				return;

			var variable = vars.Get(name);
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

		public static Boolean Compare(Double operand, ComparisonOperator op, Variable rhs)
		{
			if (rhs == null)
				return Compare(operand, op, 0.0);

			if (!rhs.IsNumber)
			{
				GameEngine.Actions.LogWarn("IsVariable: right-hand side is not numeric; comparison skipped.");
				return false;
			}

			return Compare(operand, op, rhs.Number);
		}
	}
}
