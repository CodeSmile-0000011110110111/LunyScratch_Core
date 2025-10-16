using System;

namespace LunyScratch
{
	internal sealed class EnableObjectBlock : IScratchBlock
	{
		private readonly String _childName;

		public EnableObjectBlock(String childName) => _childName = childName;

		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			if (context == null)
				return;

			IEngineObject target;
			if (_childName == null)
				target = context.Self;
			else
				target = context.FindChild(_childName);

			target?.SetEnabled(true);
		}

		public Boolean IsComplete() => true;
	}
}
