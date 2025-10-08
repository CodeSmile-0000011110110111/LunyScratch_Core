using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		/// <summary>
		/// Creates an event-style block that waits until the given condition becomes true, then runs the provided blocks once.
		/// One-shot edge-triggered.
		/// </summary>
		public static IScratchBlock When(Func<Boolean> condition, params IScratchBlock[] blocks) => new WhenBlock(condition, blocks);
	}
}
