using System;

namespace LunyScratch
{
	/// <summary>
	/// Null context for global blocks that don't have a GameObject context.
	/// </summary>
	internal sealed class GlobalScratchContext : IScratchContext
	{
		public static readonly GlobalScratchContext Null = new();

		public IRigidbody Rigidbody => null;

		public ITransform Transform => null;

		public IAudioSource AudioSource => null;

		public IEngineObject Self => null;

		private GlobalScratchContext() {}

		public void ScheduleDestroy() {}
		public IEngineObject FindChild(String name) => null;
	}
}
