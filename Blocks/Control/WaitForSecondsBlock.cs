using System;

namespace LunyScratch
{
	internal sealed class WaitForSecondsBlock : IScratchBlock
	{
		private readonly Double _duration;
		private Double _elapsed;

		public WaitForSecondsBlock(Double duration)
		{
			_duration = duration;
			_elapsed = 0;
		}

		public void OnEnter() => _elapsed = 0;
		public void Run(IScratchContext context, Double deltaTimeInSeconds) => _elapsed += deltaTimeInSeconds;
		public Boolean IsComplete() => _elapsed >= _duration;
	}
}
