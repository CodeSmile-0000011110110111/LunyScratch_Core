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
		/// Gets the IAudioSource for this context. Returns null if no AudioSource component exists.
		/// </summary>
		IEngineAudioSource Audio { get; }

		/// <summary>
		/// Gets the current object as an engine-agnostic IEngineObject.
		/// </summary>
		IEngineObject Self { get; }
		IScratchRunner Runner { get; }
		
		/// <summary>
		/// Gets the active camera for this context, if any.
		/// </summary>
		IEngineCamera ActiveCamera { get; }

		/// <summary>
		/// Provides engine-agnostic UI accessors. Implementations should return a new adapter instance per call.
		/// </summary>
		IEngineHUD GetEngineHUD();
		IEngineMenu GetEngineMenu();
		
		void ScheduleDestroy();

		/// <summary>
		/// Finds a child game object by name in the hierarchy and returns it as an IEngineObject.
		/// The search includes all descendants (recursive).
		/// Returns null if not found.
		/// Results are cached by name for performance.
		/// </summary>
		IEngineObject FindChild(String name);

		/// <summary>
		/// Attempts to consume a queued collision-enter event matching optional name/tag filters.
		/// Returns true if an event was found and consumed.
		/// </summary>
		Boolean QueryCollisionEnterEvents(String nameFilter, String tagFilter);
	}
}
