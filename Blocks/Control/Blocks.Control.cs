using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IScratchBlock Sequence(params IScratchBlock[] blocks) => new SequenceBlock(blocks);
		public static IScratchBlock Wait(Double seconds) => new WaitForSecondsBlock(seconds);
		public static IScratchBlock Enable(String childName) => new EnableObjectBlock(childName);
		public static IScratchBlock Enable() => new EnableObjectBlock(null);
		public static IScratchBlock Disable(String childName) => new DisableObjectBlock(childName);
		public static IScratchBlock Disable() => new DisableObjectBlock(null);
		public static IScratchBlock DestroySelf() => new DestroySelfBlock();
		public static IScratchBlock InstantiatePrefab(String prefabPath) => new InstantiatePrefabBlock(prefabPath);
	}
}
