using System;

namespace LunyScratch
{
	internal sealed class DestroySelfBlock : IScratchBlock
	{
		public void Run(IScratchContext context, Double deltaTimeInSeconds) => context?.ScheduleDestroy();

		public Boolean IsComplete() => true;
	}
}
