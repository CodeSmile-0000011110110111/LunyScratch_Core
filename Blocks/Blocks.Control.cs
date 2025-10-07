using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		// TIME
		public static IScratchBlock Wait(Double seconds) => new WaitBlock(seconds);

		// ACTIVE
		public static IScratchBlock Enable(IEngineObject obj) => new ExecuteBlock(() => obj.SetEnabled(true));
		public static IScratchBlock Disable(IEngineObject obj) => new ExecuteBlock(() => obj.SetEnabled(false));

		// CONDITION
		public static IfBlock If(Func<Boolean> condition, params IScratchBlock[] blocks) =>
			new IfBlock(condition, new System.Collections.Generic.List<IScratchBlock>(blocks));

		public static IfBlock If(ConditionBlock condition, params IScratchBlock[] blocks) =>
			new IfBlock(condition, new System.Collections.Generic.List<IScratchBlock>(blocks));

		// LOOPS
		public static IScratchBlock RepeatForever(params IScratchBlock[] blocks) => new RepeatForeverBlock(blocks);
		public static IScratchBlock RepeatForever(Action block) => RepeatForever(new ExecuteBlock(block));

		public static IScratchBlock RepeatWhileTrue(Func<Boolean> condition, params IScratchBlock[] blocks) =>
			new RepeatWhileTrueBlock(condition, blocks);

		public static IScratchBlock RepeatWhileTrue(ConditionBlock condition, params IScratchBlock[] blocks) =>
			new RepeatWhileTrueBlock(condition, blocks);

		public static IScratchBlock RepeatUntilTrue(Func<Boolean> condition, params IScratchBlock[] blocks) =>
			new RepeatUntilTrueBlock(condition, blocks);

		public static IScratchBlock RepeatUntilTrue(ConditionBlock condition, params IScratchBlock[] blocks) =>
			new RepeatUntilTrueBlock(condition, blocks);
	}
}
