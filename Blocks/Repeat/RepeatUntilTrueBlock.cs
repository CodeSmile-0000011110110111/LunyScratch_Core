using System;
using System.Collections.Generic;

namespace LunyScratch
{
	internal sealed class RepeatUntilTrueBlock : RepeatBlockBase
	{
		public RepeatUntilTrueBlock(Func<Boolean> condition, params IScratchBlock[] blocks)
			: base(new ConditionBlock(condition), blocks) {}

		public RepeatUntilTrueBlock(Func<Boolean> condition, List<IScratchBlock> blocks)
			: base(new ConditionBlock(condition), blocks) {}

		public RepeatUntilTrueBlock(ConditionBlock condition, params IScratchBlock[] blocks)
			: base(condition, blocks) {}

		public RepeatUntilTrueBlock(ConditionBlock condition, List<IScratchBlock> blocks)
			: base(condition, blocks) {}

		protected override Boolean ShouldExitLoop(IScratchContext context) => EvaluateCondition(context); // Exit when condition becomes true
	}
}
