using System;

namespace LunyScratch
{
	internal static class GameEngine
	{
		private static IEngineRuntime s_Runtime;
		private static IEngineActions s_Actions;
		private static AssetRegistry.IAssetRegistry s_AssetRegistry;

		internal static IEngineRuntime Runtime => s_Runtime ?? throw new Exception("Scratch Engine: Runtime not initialized");
		internal static IEngineActions Actions => s_Actions ?? throw new Exception("Scratch Engine: Actions not initialized");
		internal static AssetRegistry.IAssetRegistry AssetRegistry => s_AssetRegistry ?? throw new Exception("Scratch Engine: AssetRegistry not initialized");

		internal static void Initialize(IEngineRuntime runtime, IEngineActions actions, AssetRegistry.IAssetRegistry assetRegistry)
		{
			s_Runtime = runtime;
			s_Actions = actions;
			s_AssetRegistry = assetRegistry ?? throw new Exception("Scratch Engine: AssetRegistry is null during initialization");
		}

		internal static void Shutdown()
		{
			s_Runtime = null;
			s_Actions = null;
			s_AssetRegistry = null;
		}
	}
}
