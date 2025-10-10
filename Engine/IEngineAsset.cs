namespace LunyScratch
{
	/// <summary>
	/// Base interface for engine asset wrappers. Engine-specific implementations wrap native engine asset objects.
	/// </summary>
	public interface IEngineAsset { }

	/// <summary>
	/// Prefab asset wrapper (e.g., Unity GameObject prefab).
	/// </summary>
	public interface IEnginePrefabAsset : IEngineAsset { }

	/// <summary>
	/// UI asset wrapper (e.g., Unity UI Toolkit VisualTreeAsset).
	/// </summary>
	public interface IEngineUIAsset : IEngineAsset { }

	/// <summary>
	/// Audio asset wrapper (e.g., Unity AudioClip).
	/// </summary>
	public interface IEngineAudioAsset : IEngineAsset { }
}
