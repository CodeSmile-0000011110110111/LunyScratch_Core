using System;

namespace LunyScratch
{
	/// <summary>
	/// Instantiates a prefab from the AssetRegistry at the same position and rotation as the context object.
	/// The new instance is not parented to the context object.
	/// </summary>
	internal sealed class InstantiatePrefabBlock : IScratchBlock
	{
		private readonly string _prefabPath;

		public InstantiatePrefabBlock(string prefabPath)
		{
			_prefabPath = prefabPath;
		}

		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			var transform = context?.Transform;
			if (transform == null)
				return;

			var prefab = AssetRegistry.Get<IEnginePrefabAsset>(_prefabPath);
			GameEngine.Actions.InstantiatePrefab(prefab, transform);
		}

		public Boolean IsComplete() => true;
	}
}
