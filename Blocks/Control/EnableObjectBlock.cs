using System;

namespace LunyScratch
{
	internal sealed class EnableObjectBlock : IScratchBlock
	{
		private readonly String _childName;

		public EnableObjectBlock(String childName) => _childName = childName;

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
}
