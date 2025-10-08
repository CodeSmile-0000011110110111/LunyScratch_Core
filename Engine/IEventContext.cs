using System;

namespace LunyScratch
{
	/// <summary>
	/// Internal engine-agnostic event access for blocks via IScratchContext downcast.
	/// Implemented by engine-specific contexts (e.g., UnityGameObjectContext).
	/// </summary>
	internal interface IEventContext
	{
		/// <summary>
		/// Attempts to consume a queued collision-enter event matching optional name/tag filters.
		/// Returns true if an event was found and consumed.
		/// </summary>
		Boolean QueryCollisionEnterEvents(String nameFilter, String tagFilter);
	}
}
