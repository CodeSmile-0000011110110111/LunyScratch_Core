using System;

namespace LunyScratch
{
	public interface IRigidbody
	{
		IVector3 LinearVelocity { get; }
		IVector3 AngularVelocity { get; }
		IVector3 Position { get; }
		IVector3 Forward { get; }

		void SetLinearVelocity(Single x, Single y, Single z);
		void SetAngularVelocity(Single x, Single y, Single z);
		void SetPosition(Single x, Single y, Single z);
	}
}
