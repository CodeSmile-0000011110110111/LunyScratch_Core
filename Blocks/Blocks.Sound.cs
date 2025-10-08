using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IScratchBlock PlaySound() => new PlaySoundBlock();

		private sealed class PlaySoundBlock : IScratchBlock
		{
			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var audio = context?.AudioSource;
				audio?.Play();
			}

			public Boolean IsComplete() => true;
		}
	}
}
