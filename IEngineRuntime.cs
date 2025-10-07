namespace LunyScratch
{
	internal interface IEngineRuntime
	{
		void RunBlock(IScratchBlock block);
		void RunPhysicsBlock(IScratchBlock block);
	}
}
