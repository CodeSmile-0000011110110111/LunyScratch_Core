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

			IEngineObject target;
			if (_childName == null)
				target = context.Self;
			else
				target = context.FindChild(_childName);

			target?.SetEnabled(false);
		}

		public Boolean IsComplete() => true;
	}
}
