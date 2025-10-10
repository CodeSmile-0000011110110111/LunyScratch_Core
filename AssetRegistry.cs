using System;

namespace LunyScratch
{
	/// <summary>
	/// Provides fast lookup of registered assets by type and path.
	/// Uses the engine-provided registry set during GameEngine initialization.
	/// If an asset for the given path/type is missing or resolves to null, a warning is logged and
	/// a default placeholder asset of the requested type is returned.
	/// </summary>
	public static class AssetRegistry
	{
		internal interface IAssetRegistry
		{
			T Get<T>(string path) where T : class, IEngineAsset;
			IEngineAsset Get(string path, Type assetType);
			T GetPlaceholder<T>() where T : class, IEngineAsset;
			IEngineAsset GetPlaceholder(Type assetType);
		}

		public static T Get<T>(string path) where T : class, IEngineAsset
		{
			var source = GameEngine.AssetRegistry;
			var asset = source.Get<T>(path);
			if (asset == null)
			{
				GameEngine.Actions.LogWarn($"AssetRegistry: Asset not found or null for path '{path}' and type {typeof(T).Name}; returning placeholder.");
				return source.GetPlaceholder<T>();
			}
			return asset;
		}
	}
}
