using System;

namespace LunyScratch
{
	internal sealed class TurnRightBlock : IScratchBlock
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
}
