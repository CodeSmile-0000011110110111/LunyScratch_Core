using System;

namespace LunyScratch
{
	// Dedicated NOT condition
	internal sealed class NotConditionBlock : ConditionBlock
	{
		private static Func<IScratchContext, Boolean> BuildEvaluator(ConditionBlock condition) =>
			context => !(condition != null && condition.Evaluate(context));

		public NotConditionBlock(ConditionBlock condition)
			: base(BuildEvaluator(condition)) {}
	}
}
