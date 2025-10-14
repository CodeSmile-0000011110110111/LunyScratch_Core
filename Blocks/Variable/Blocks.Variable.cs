using System;

namespace LunyScratch
{
	public static partial class Blocks
	{
		// Name-based variants (operate via context Table)
		public static IScratchBlock IncrementVariable(String name) => new ModifyVariableByNameBlock(name, MathOperator.Add, 1.0);
		public static IScratchBlock DecrementVariable(String name) => new ModifyVariableByNameBlock(name, MathOperator.Subtract, 1.0);
		public static IScratchBlock AddVariable(String name, Double amount) => new ModifyVariableByNameBlock(name, MathOperator.Add, amount);
		public static IScratchBlock SubtractVariable(String name, Double amount) => new ModifyVariableByNameBlock(name, MathOperator.Subtract, amount);
		public static IScratchBlock MultiplyVariable(String name, Double by) => new ModifyVariableByNameBlock(name, MathOperator.Multiply, by);
		public static IScratchBlock DivideVariable(String name, Double by) => new ModifyVariableByNameBlock(name, MathOperator.Divide, by);
		public static IScratchBlock ModuloVariable(String name, Double by) => new ModifyVariableByNameBlock(name, MathOperator.Modulo, by);
		public static IScratchBlock SetVariable(String name, Double value) => new ModifyVariableByNameBlock(name, MathOperator.Assign, value);

		// Variable instance variants (operate on provided Variable)
		public static IScratchBlock IncrementVariable(Variable variable) => new ModifyVariableBlock(variable, MathOperator.Add, 1.0);
		public static IScratchBlock DecrementVariable(Variable variable) => new ModifyVariableBlock(variable, MathOperator.Subtract, 1.0);
		public static IScratchBlock AddVariable(Variable variable, Double amount) => new ModifyVariableBlock(variable, MathOperator.Add, amount);
		public static IScratchBlock SubtractVariable(Variable variable, Double amount) => new ModifyVariableBlock(variable, MathOperator.Subtract, amount);
		public static IScratchBlock MultiplyVariable(Variable variable, Double by) => new ModifyVariableBlock(variable, MathOperator.Multiply, by);
		public static IScratchBlock DivideVariable(Variable variable, Double by) => new ModifyVariableBlock(variable, MathOperator.Divide, by);
		public static IScratchBlock ModuloVariable(Variable variable, Double by) => new ModifyVariableBlock(variable, MathOperator.Modulo, by);
		public static IScratchBlock SetVariable(Variable variable, Double value) => new ModifyVariableBlock(variable, MathOperator.Assign, value);

		// Variable comparison conditions (by Variable instance)
		public static ConditionBlock IsVariableLessThan(Variable variable, Double value) => new IsVariableConditionBlock(variable, value, ComparisonOperator.Less);
		public static ConditionBlock IsVariableLessOrEqual(Variable variable, Double value) => new IsVariableConditionBlock(variable, value, ComparisonOperator.LessOrEqual);
		public static ConditionBlock IsVariableEqualTo(Variable variable, Double value) => new IsVariableConditionBlock(variable, value, ComparisonOperator.Equal);
		public static ConditionBlock IsVariableNotEqualTo(Variable variable, Double value) => new IsVariableConditionBlock(variable, value, ComparisonOperator.NotEqual);
		public static ConditionBlock IsVariableGreaterThan(Variable variable, Double value) => new IsVariableConditionBlock(variable, value, ComparisonOperator.Greater);
		public static ConditionBlock IsVariableGreaterOrEqual(Variable variable, Double value) => new IsVariableConditionBlock(variable, value, ComparisonOperator.GreaterOrEqual);

		// Variable comparison conditions (by name via context Table)
		public static ConditionBlock IsVariableLessThan(String name, Double value) => new IsVariableConditionBlock(name, value, ComparisonOperator.Less);
		public static ConditionBlock IsVariableLessOrEqual(String name, Double value) => new IsVariableConditionBlock(name, value, ComparisonOperator.LessOrEqual);
		public static ConditionBlock IsVariableEqualTo(String name, Double value) => new IsVariableConditionBlock(name, value, ComparisonOperator.Equal);
		public static ConditionBlock IsVariableNotEqualTo(String name, Double value) => new IsVariableConditionBlock(name, value, ComparisonOperator.NotEqual);
		public static ConditionBlock IsVariableGreaterThan(String name, Double value) => new IsVariableConditionBlock(name, value, ComparisonOperator.Greater);
		public static ConditionBlock IsVariableGreaterOrEqual(String name, Double value) => new IsVariableConditionBlock(name, value, ComparisonOperator.GreaterOrEqual);
	}
}
