namespace LunyScratch
{
	public static partial class Blocks
	{
		/// <summary>
		/// Clears the active camera's tracking target (engine-agnostic).
		/// </summary>
		public static IScratchBlock SetCameraTrackingTarget(IEngineObject target) => new SetCameraTrackingTargetBlock(target);
	}
}
