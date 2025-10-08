namespace LunyScratch
{
	/// <summary>
	/// Provides context for block execution, allowing blocks to access components and game objects.
	/// </summary>
	public interface IScratchContext
	{
		/// <summary>
		/// Gets a component of the specified type attached to this context's game object.
		/// Returns null if no component is found.
		/// </summary>
		T GetComponent<T>() where T : class;

		/// <summary>
		/// Gets all components of the specified type in children of this context's game object.
		/// </summary>
		T[] GetComponentsInChildren<T>() where T : class;

		/// <summary>
		/// Gets the IRigidbody for this context. Returns null if no Rigidbody component exists.
		/// </summary>
		IRigidbody GetRigidbody();

		/// <summary>
		/// Gets the ITransform for this context. Returns null if no Transform exists.
		/// </summary>
		ITransform GetTransform();

		/// <summary>
		/// Finds a child game object by name in the hierarchy and returns it as an IEngineObject.
		/// The search includes all descendants (recursive).
		/// Returns null if not found.
		/// Results are cached by name for performance.
		/// </summary>
		IEngineObject FindChild(System.String name);
	}
}
