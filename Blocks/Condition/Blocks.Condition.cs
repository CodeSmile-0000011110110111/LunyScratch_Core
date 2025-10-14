using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		public static IfBlock If(ConditionBlock condition, params IScratchBlock[] blocks) => new(condition, blocks);
		public static IfBlock If(Func<Boolean> condition, params IScratchBlock[] blocks) => new(condition, blocks);

		// Condition combinators
		public static ConditionBlock AND(params ConditionBlock[] conditions) => new AndConditionBlock(conditions);
		public static ConditionBlock OR(params ConditionBlock[] conditions) => new OrConditionBlock(conditions);
		public static ConditionBlock NOT(ConditionBlock condition) => new NotConditionBlock(condition);
		public static ConditionBlock XOR(params ConditionBlock[] conditions) => new XorConditionBlock(conditions);
		public static ConditionBlock NAND(params ConditionBlock[] conditions) => NOT(AND(conditions));
		public static ConditionBlock NOR(params ConditionBlock[] conditions) => NOT(OR(conditions));
		public static ConditionBlock XNOR(params ConditionBlock[] conditions) => NOT(XOR(conditions));
	}
}
