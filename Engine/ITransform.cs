using System;

namespace LunyScratch
{
	public interface ITransform
	{
		IVector3 Position { get; }
		IVector3 Forward { get; }

		void SetPosition(Single x, Single y, Single z);
	}
}
