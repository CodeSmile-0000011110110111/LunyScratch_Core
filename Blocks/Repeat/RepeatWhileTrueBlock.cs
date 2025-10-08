using System;
using System.Collections.Generic;

namespace LunyScratch
{
	internal sealed class RepeatWhileTrueBlock : RepeatBlockBase
	{
		public RepeatWhileTrueBlock(Func<Boolean> condition, params IScratchBlock[] blocks)
			: base(new ConditionBlock(condition), blocks) {}

		public RepeatWhileTrueBlock(Func<Boolean> condition, List<IScratchBlock> blocks)
			: base(new ConditionBlock(condition), blocks) {}

		public RepeatWhileTrueBlock(ConditionBlock condition, params IScratchBlock[] blocks)
			: base(condition, blocks) {}

		public RepeatWhileTrueBlock(ConditionBlock condition, List<IScratchBlock> blocks)
			: base(condition, blocks) {}

		protected override Boolean ShouldExitLoop() => !EvaluateCondition(); // Exit when condition becomes false
	}
}
