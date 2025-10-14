using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		/// <summary>
		/// Returns a condition that checks the current context Rigidbody's linear speed against a threshold (m/s)
		/// using the specified comparison operator. Uses squared magnitudes to avoid sqrt.
		/// </summary>
		public static ConditionBlock IsLinearVelocity(Double metersPerSecond, ComparisonOperator op)
		{
			return new IsLinearVelocityConditionBlock(metersPerSecond, op);
		}

		public static ConditionBlock IsLinearVelocityLessThan(Double thresholdMetersPerSecond) =>
			IsLinearVelocity(thresholdMetersPerSecond, ComparisonOperator.Less);

		public static ConditionBlock IsLinearVelocityLessOrEqual(Double thresholdMetersPerSecond) =>
			IsLinearVelocity(thresholdMetersPerSecond, ComparisonOperator.LessOrEqual);

		public static ConditionBlock IsLinearVelocityEqualTo(Double thresholdMetersPerSecond) =>
			IsLinearVelocity(thresholdMetersPerSecond, ComparisonOperator.Equal);

		public static ConditionBlock IsLinearVelocityNotEqualTo(Double thresholdMetersPerSecond) =>
			IsLinearVelocity(thresholdMetersPerSecond, ComparisonOperator.NotEqual);

		public static ConditionBlock IsLinearVelocityGreaterThan(Double thresholdMetersPerSecond) =>
			IsLinearVelocity(thresholdMetersPerSecond, ComparisonOperator.Greater);

		public static ConditionBlock IsLinearVelocityGreaterOrEqual(Double thresholdMetersPerSecond) =>
			IsLinearVelocity(thresholdMetersPerSecond, ComparisonOperator.GreaterOrEqual);
	}
}
