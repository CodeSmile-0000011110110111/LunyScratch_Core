using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IScratchBlock Enable(String childName) => new EnableByNameBlock(childName);
		public static IScratchBlock Disable(String childName) => new DisableByNameBlock(childName);

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
