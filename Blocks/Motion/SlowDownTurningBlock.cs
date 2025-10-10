using System;

namespace LunyScratch
{
	internal sealed class SlowDownTurningBlock : IScratchBlock
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
