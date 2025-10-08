using System;

namespace LunyScratch
{
	/// <summary>
	/// Provides context for block execution, allowing blocks to access components and game objects.
	/// </summary>
	public interface IScratchContext
	{
		/// <summary>
		/// Gets the IRigidbody for this context. Returns null if no Rigidbody component exists.
		/// </summary>
		IRigidbody Rigidbody { get; }

		/// <summary>
		/// Gets the ITransform for this context. Returns null if no Transform exists.
		/// </summary>
		ITransform Transform { get; }

		/// <summary>
		/// Finds a child game object by name in the hierarchy and returns it as an IEngineObject.
		/// The search includes all descendants (recursive).
		/// Returns null if not found.
		/// Results are cached by name for performance.
		/// </summary>
		IEngineObject FindChild(String name);
	}
}
