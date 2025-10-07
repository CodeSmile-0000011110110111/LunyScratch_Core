using log4net.Appender;
using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IScratchBlock MoveForward(IRigidbody rigidbody, Single speed) => new ExecuteBlock(Move(rigidbody, speed));

		public static IScratchBlock MoveBackward(IRigidbody rigidbody, Single speed) => new ExecuteBlock(Move(rigidbody, -speed));

		public static IScratchBlock StopMoving(IRigidbody rigidbody) => new ExecuteBlock(() =>
		{
			var currentVel = rigidbody.LinearVelocity;
			rigidbody.SetLinearVelocity(0, currentVel.Y, 0);
		});

		public static IScratchBlock SlowDownMoving(IRigidbody rigidbody, Single factor) => new ExecuteBlock(() =>
		{
			var vel = rigidbody.LinearVelocity;
			rigidbody.SetLinearVelocity(vel.X * factor, vel.Y, vel.Z * factor);
		});

		public static IScratchBlock TurnLeft(IRigidbody rigidbody, Single degreesPerSecond) =>
			new ExecuteBlock(Turn(rigidbody, -degreesPerSecond));

		public static IScratchBlock TurnRight(IRigidbody rigidbody, Single degreesPerSecond) =>
			new ExecuteBlock(Turn(rigidbody, degreesPerSecond));

		public static IScratchBlock StopTurning(IRigidbody rigidbody) => new ExecuteBlock(() => rigidbody.SetAngularVelocity(0, 0, 0));

		public static IScratchBlock SlowDownTurning(IRigidbody rigidbody, Single factor) => new ExecuteBlock(() =>
		{
			var angVel = rigidbody.AngularVelocity;
			rigidbody.SetAngularVelocity(angVel.X * factor, angVel.Y * factor, angVel.Z * factor);
		});

		private static Action Move(IRigidbody rigidbody, Single speed) => () =>
		{
			var forward = rigidbody.Forward;
			var currentVel = rigidbody.LinearVelocity;
			rigidbody.SetLinearVelocity(forward.X * speed, currentVel.Y, forward.Z * speed);
		};

		private static Action Turn(IRigidbody rigidbody, Single degreesPerSecond) => () =>
		{
			// Convert degrees per second to radians per second (Physics uses radians for angularVelocity)
			var radiansPerSecond = degreesPerSecond * (Single)(Math.PI / 180.0);
			rigidbody.SetAngularVelocity(0, radiansPerSecond, 0);
		};
	}
}
