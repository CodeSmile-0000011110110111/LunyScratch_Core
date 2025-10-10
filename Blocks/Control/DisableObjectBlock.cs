using System;

namespace LunyScratch
{
	internal sealed class DisableObjectBlock : IScratchBlock
	{
		private readonly String _childName;

		public DisableObjectBlock(String childName) => _childName = childName;

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
}
