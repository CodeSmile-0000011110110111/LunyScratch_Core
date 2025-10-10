using System;

namespace LunyScratch
{
	internal sealed class StopMovingBlock : IScratchBlock
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
}
