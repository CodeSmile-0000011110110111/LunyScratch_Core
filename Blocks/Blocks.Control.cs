using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		// TIME
		public static IScratchBlock Wait(Double seconds) => new WaitBlock(seconds);

		// ACTIVE - Direct object reference
		public static IScratchBlock Enable(IEngineObject obj) => new ExecuteBlock(() => obj.SetEnabled(true));
		public static IScratchBlock Disable(IEngineObject obj) => new ExecuteBlock(() => obj.SetEnabled(false));

		// ACTIVE - Context-aware (find by name)
		public static IScratchBlock Enable(String childName) => new EnableByNameBlock(childName);
		public static IScratchBlock Disable(String childName) => new DisableByNameBlock(childName);

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

		// Context-aware block implementations
		private sealed class EnableByNameBlock : IScratchBlock
		{
			private readonly String _childName;

			public EnableByNameBlock(String childName) => _childName = childName;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var child = context?.FindChild(_childName);
				child?.SetEnabled(true);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class DisableByNameBlock : IScratchBlock
		{
			private readonly String _childName;

			public DisableByNameBlock(String childName) => _childName = childName;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				var child = context?.FindChild(_childName);
				child?.SetEnabled(false);
			}

			public Boolean IsComplete() => true;
		}
	}
}
