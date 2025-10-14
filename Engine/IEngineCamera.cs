using System;

namespace LunyScratch
{
	public interface IEngineCamera
	{
		/// <summary>
		/// Sets the camera tracking target. Pass null to clear tracking.
		/// </summary>
		void SetTrackingTarget(IEngineObject target);
	}
}
