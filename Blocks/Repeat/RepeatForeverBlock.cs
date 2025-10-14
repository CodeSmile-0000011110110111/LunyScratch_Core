using System;

namespace LunyScratch
{
	internal sealed class RepeatForeverBlock : RepeatBlockBase
	{
		private static readonly ConditionBlock s_DummyCondition = new(() => false);

		public RepeatForeverBlock(params IScratchBlock[] blocks)
			: base(s_DummyCondition, blocks) {}

		protected override Boolean ShouldExitLoop(IScratchContext context) => false; // Never exits
	}
}
