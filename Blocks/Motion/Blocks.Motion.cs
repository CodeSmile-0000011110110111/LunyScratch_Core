using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IScratchBlock MoveForward(Single speed) => new MoveForwardBlock(speed);
		public static IScratchBlock MoveBackward(Single speed) => new MoveBackwardBlock(speed);
		public static IScratchBlock StopMoving() => new StopMovingBlock();
		public static IScratchBlock SlowDownMoving(Single factor) => new SlowDownMovingBlock(factor);
		public static IScratchBlock TurnLeft(Single degreesPerSecond) => new TurnLeftBlock(degreesPerSecond);
		public static IScratchBlock TurnRight(Single degreesPerSecond) => new TurnRightBlock(degreesPerSecond);
		public static IScratchBlock StopTurning() => new StopTurningBlock();
		public static IScratchBlock SlowDownTurning(Single factor) => new SlowDownTurningBlock(factor);

		/// <summary>
		/// Returns a condition that checks the current context Rigidbody's linear speed against a threshold (m/s)
		/// using the specified comparison operator. Uses squared magnitudes to avoid sqrt.
		/// </summary>
		public static ConditionBlock IsVelocity(Double metersPerSecond, ComparisonOperator op = ComparisonOperator.Equal) =>
			new IsLinearVelocityConditionBlock(metersPerSecond, op);

		public static ConditionBlock IsVelocityLess(Double thresholdMetersPerSecond) =>
			IsVelocity(thresholdMetersPerSecond, ComparisonOperator.Less);

		public static ConditionBlock IsVelocityLessOrEqual(Double thresholdMetersPerSecond) =>
			IsVelocity(thresholdMetersPerSecond, ComparisonOperator.LessOrEqual);

		public static ConditionBlock IsVelocityEqual(Double thresholdMetersPerSecond) => IsVelocity(thresholdMetersPerSecond);

		public static ConditionBlock IsVelocityNotEqual(Double thresholdMetersPerSecond) =>
			IsVelocity(thresholdMetersPerSecond, ComparisonOperator.NotEqual);

		public static ConditionBlock IsCurrentSpeedGreater(Double thresholdMetersPerSecond) =>
			IsVelocity(thresholdMetersPerSecond, ComparisonOperator.Greater);

		public static ConditionBlock IsVelocityGreaterOrEqual(Double thresholdMetersPerSecond) =>
			IsVelocity(thresholdMetersPerSecond, ComparisonOperator.GreaterOrEqual);
	}
}
