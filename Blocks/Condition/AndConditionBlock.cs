using System;
using System.Collections.Generic;

namespace LunyScratch
{
	// Dedicated AND condition supporting short-circuit evaluation
	internal sealed class AndConditionBlock : ConditionBlock
	{
		private static Func<IScratchContext, Boolean> BuildEvaluator(List<ConditionBlock> conditions) => context =>
		{
			// Identity for empty set is true
			if (conditions == null || conditions.Count == 0)
				return true;

			for (var i = 0; i < conditions.Count; i++)
			{
				if (!conditions[i].Evaluate(context))
					return false; // short-circuit on first false
			}
			return true;
		};

		public AndConditionBlock(List<ConditionBlock> conditions)
			: base(BuildEvaluator(conditions)) {}

		public AndConditionBlock(params ConditionBlock[] conditions)
			: base(BuildEvaluator(conditions != null ? new List<ConditionBlock>(conditions) : new List<ConditionBlock>())) {}
	}
}
