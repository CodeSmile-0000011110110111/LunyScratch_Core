using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IfBlock If(Func<Boolean> condition, params IScratchBlock[] blocks) =>
			new IfBlock(condition, new System.Collections.Generic.List<IScratchBlock>(blocks));

		public static IfBlock If(ConditionBlock condition, params IScratchBlock[] blocks) =>
			new IfBlock(condition, new System.Collections.Generic.List<IScratchBlock>(blocks));
	}
}
