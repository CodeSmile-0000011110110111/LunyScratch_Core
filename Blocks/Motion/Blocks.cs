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
	}
}
