using System;

namespace LunyScratch;

internal static class GameEngine
{
	private static IEngineRuntime? s_Runtime;
	private static IEngineActions? s_Actions;

	internal static IEngineRuntime Runtime => s_Runtime ?? throw new Exception("Scratch Engine: Runtime not initialized");
	internal static IEngineActions Actions => s_Actions ?? throw new Exception("Scratch Engine: Actions not initialized");

	internal static void Initialize(IEngineRuntime runtime, IEngineActions actions)
	{
		s_Runtime = runtime;
		s_Actions = actions;
	}

	internal static void Shutdown()
	{
		s_Runtime = null;
		s_Actions = null;
	}
}
