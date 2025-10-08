using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IScratchBlock Sequence(params IScratchBlock[] blocks) => new SequenceBlock(blocks);
		public static IScratchBlock Enable(String childName) => new EnableBlock(childName);
		public static IScratchBlock Enable() => new EnableBlock(null);
		public static IScratchBlock Disable(String childName) => new DisableBlock(childName);
		public static IScratchBlock Disable() => new DisableBlock(null);
		public static IScratchBlock DestroySelf() => new DestroySelfBlock();

		private sealed class EnableBlock : IScratchBlock
		{
			private readonly String _childName;

			public EnableBlock(String childName) => _childName = childName;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				if (context == null) return;
				if (_childName == null)
					context.Self?.SetEnabled(true);
				else
					context.FindChild(_childName)?.SetEnabled(true);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class DisableBlock : IScratchBlock
		{
			private readonly String _childName;

			public DisableBlock(String childName) => _childName = childName;

			public void Run(IScratchContext context, Double deltaTimeInSeconds)
			{
				if (context == null) return;
				if (_childName == null)
					context.Self?.SetEnabled(false);
				else
					context.FindChild(_childName)?.SetEnabled(false);
			}

			public Boolean IsComplete() => true;
		}

		private sealed class DestroySelfBlock : IScratchBlock
		{
			public void Run(IScratchContext context, Double deltaTimeInSeconds) => context?.ScheduleDestroy();

			public Boolean IsComplete() => true;
		}
	}
}
