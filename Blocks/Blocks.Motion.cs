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

		// Context-aware block implementations - no caching, context does that
		private sealed class MoveForwardBlock : IScratchBlock
		{
			private readonly Single _speed;

			public MoveForwardBlock(Single speed) => _speed = speed;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var rigidbody = context?.Rigidbody;
				if (rigidbody == null) return;

				var forward = rigidbody.Forward;
				var currentVel = rigidbody.LinearVelocity;
				rigidbody.SetLinearVelocity(forward.X * _speed, currentVel.Y, forward.Z * _speed);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class MoveBackwardBlock : IScratchBlock
		{
			private readonly Single _speed;

			public MoveBackwardBlock(Single speed) => _speed = speed;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var rigidbody = context?.Rigidbody;
				if (rigidbody == null) return;

				var forward = rigidbody.Forward;
				var currentVel = rigidbody.LinearVelocity;
				rigidbody.SetLinearVelocity(forward.X * -_speed, currentVel.Y, forward.Z * -_speed);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class StopMovingBlock : IScratchBlock
		{
			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var rigidbody = context?.Rigidbody;
				if (rigidbody == null) return;

				var currentVel = rigidbody.LinearVelocity;
				rigidbody.SetLinearVelocity(0, currentVel.Y, 0);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class SlowDownMovingBlock : IScratchBlock
		{
			private readonly Single _factor;

			public SlowDownMovingBlock(Single factor) => _factor = factor;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var rigidbody = context?.Rigidbody;
				if (rigidbody == null) return;

				var vel = rigidbody.LinearVelocity;
				rigidbody.SetLinearVelocity(vel.X * _factor, vel.Y, vel.Z * _factor);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class TurnLeftBlock : IScratchBlock
		{
			private readonly Single _degreesPerSecond;

			public TurnLeftBlock(Single degreesPerSecond) => _degreesPerSecond = degreesPerSecond;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var rigidbody = context?.Rigidbody;
				if (rigidbody == null) return;

				var radiansPerSecond = -_degreesPerSecond * (Single)(Math.PI / 180.0);
				rigidbody.SetAngularVelocity(0, radiansPerSecond, 0);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class TurnRightBlock : IScratchBlock
		{
			private readonly Single _degreesPerSecond;

			public TurnRightBlock(Single degreesPerSecond) => _degreesPerSecond = degreesPerSecond;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var rigidbody = context?.Rigidbody;
				if (rigidbody == null) return;

				var radiansPerSecond = _degreesPerSecond * (Single)(Math.PI / 180.0);
				rigidbody.SetAngularVelocity(0, radiansPerSecond, 0);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class StopTurningBlock : IScratchBlock
		{
			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var rigidbody = context?.Rigidbody;
				if (rigidbody == null) return;

				rigidbody.SetAngularVelocity(0, 0, 0);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class SlowDownTurningBlock : IScratchBlock
		{
			private readonly Single _factor;

			public SlowDownTurningBlock(Single factor) => _factor = factor;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var rigidbody = context?.Rigidbody;
				if (rigidbody == null) return;

				var angVel = rigidbody.AngularVelocity;
				rigidbody.SetAngularVelocity(angVel.X * _factor, angVel.Y * _factor, angVel.Z * _factor);
			}

			public Boolean IsComplete() => true;
		}
	}
}
