using System;

namespace LunyScratch
{
	internal sealed class SlowDownMovingBlock : IScratchBlock
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
}
