using System;

namespace LunyScratch
{
	internal sealed class PlaySoundBlock : IScratchBlock
	{
		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			var audio = context?.AudioSource;
			audio?.Play();
		}

		public Boolean IsComplete() => true;
	}
}
