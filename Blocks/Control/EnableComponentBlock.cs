using System;

namespace LunyScratch
{
	internal sealed class EnableComponentBlock : IScratchBlock
	{
		public void Run(IScratchContext context, Double deltaTimeInSeconds) => context?.SetSelfComponentEnabled(true);

		public Boolean IsComplete() => true;
	}
}
