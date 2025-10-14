using System;

namespace LunyScratch
{
	internal sealed class SetCameraTrackingTargetBlock : IScratchBlock
	{
		private readonly IEngineObject _target;

		public SetCameraTrackingTargetBlock(IEngineObject target) => _target = target;

		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			var cam = context?.ActiveCamera;
			cam?.SetTrackingTarget(_target);
		}

		public Boolean IsComplete() => true;
	}
}
