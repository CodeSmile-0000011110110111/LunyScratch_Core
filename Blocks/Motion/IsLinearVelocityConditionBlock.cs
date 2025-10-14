using System;

namespace LunyScratch
{
	/// <summary>
	/// Condition block that checks the current context Rigidbody's linear speed against a threshold (m/s)
	/// using the specified comparison operator. Uses squared magnitudes to avoid sqrt.
	/// </summary>
	internal sealed class IsLinearVelocityConditionBlock : ConditionBlock
	{
		public IsLinearVelocityConditionBlock(Double metersPerSecond, ComparisonOperator op)
			: base(ctx =>
			{
				var rb = ctx?.Rigidbody;
				if (rb == null)
					return false;

				var v = rb.LinearVelocity;
				Double magnitudeSqr = v.X * v.X + v.Y * v.Y + v.Z * v.Z;
				var thresholdSqr = metersPerSecond * metersPerSecond;

				return op switch
				{
					ComparisonOperator.Less => magnitudeSqr < thresholdSqr,
					ComparisonOperator.LessOrEqual => magnitudeSqr <= thresholdSqr,
					ComparisonOperator.Equal => Math.Abs(magnitudeSqr - thresholdSqr) <= 1e-9,
					ComparisonOperator.NotEqual => Math.Abs(magnitudeSqr - thresholdSqr) > 1e-9,
					ComparisonOperator.Greater => magnitudeSqr > thresholdSqr,
					ComparisonOperator.GreaterOrEqual => magnitudeSqr >= thresholdSqr,
					var _ => false,
				};
			}) {}
	}
}
