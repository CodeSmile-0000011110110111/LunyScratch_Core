using System;

namespace LunyScratch
{
	internal sealed class MoveForwardBlock : IScratchBlock
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
}
