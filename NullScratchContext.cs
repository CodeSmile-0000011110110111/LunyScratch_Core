namespace LunyScratch
{
	/// <summary>
	/// Null context for global blocks that don't have a GameObject context.
	/// </summary>
	internal sealed class NullScratchContext : IScratchContext
	{
		public static readonly NullScratchContext Instance = new();

		private NullScratchContext() {}

		public T GetComponent<T>() where T : class => null;

		public T[] GetComponentsInChildren<T>() where T : class => System.Array.Empty<T>();

		public IRigidbody GetRigidbody() => null;

		public ITransform GetTransform() => null;
	}
}
