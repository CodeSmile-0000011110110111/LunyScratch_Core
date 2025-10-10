using System;

namespace LunyScratch
{
	internal sealed class StopTurningBlock : IScratchBlock
	{
		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			var rigidbody = context?.Rigidbody;
			if (rigidbody == null) return;

			rigidbody.SetAngularVelocity(0, 0, 0);
		}

		public Boolean IsComplete() => true;
	}
}
