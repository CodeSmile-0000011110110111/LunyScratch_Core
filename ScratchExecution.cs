using System;

namespace LunyScratch
{
	/// <summary>
	/// Internal execution helpers for exposing ambient context to parameterless conditions
	/// and generic comparison helpers used by condition factories.
	/// </summary>
	internal static class ScratchExecution
	{
		[ThreadStatic]
		internal static IScratchContext CurrentContext;

		internal static bool Compare(Double a, Double b, ComparisonOperator op)
		{
			return op switch
			{
				ComparisonOperator.Less => a < b,
				ComparisonOperator.LessOrEqual => a <= b,
				ComparisonOperator.Equal => Math.Abs(a - b) <= 1e-9,
				ComparisonOperator.NotEqual => Math.Abs(a - b) > 1e-9,
				ComparisonOperator.Greater => a > b,
				ComparisonOperator.GreaterOrEqual => a >= b,
				_ => false
			};
		}
	}
}
