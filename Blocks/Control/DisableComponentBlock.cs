using System;

namespace LunyScratch
{
	internal sealed class DisableComponentBlock : IScratchBlock
	{
		public void Run(IScratchContext context, Double deltaTimeInSeconds) => context?.SetSelfComponentEnabled(false);

		public Boolean IsComplete() => true;
	}
}
