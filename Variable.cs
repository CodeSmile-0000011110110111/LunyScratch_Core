using System;

namespace LunyScratch
{
	public enum ValueType
	{
		Nil = 0,
		Boolean,
		Number,
		String,
	}

	public struct Variable
	{
		private ValueType _valueType;
		private Double _number;
		private String _string;

		public ValueType Type => _valueType;
		public Boolean IsNumeric => _valueType == ValueType.Number;
		public Boolean IsBoolean => _valueType == ValueType.Boolean;
		public Boolean IsString => _valueType == ValueType.String;

		public Variable(Boolean truthValue)
		{
			_valueType = ValueType.Boolean;
			_number = truthValue ? 1 : 0;
			_string = null;
		}

		public Variable(Double number)
		{
			_valueType = ValueType.Number;
			_number = number;
			_string = null;
		}

		public Variable(String text)
		{
			_valueType = ValueType.String;
			_number = 0;
			_string = text == null ? String.Empty : text;
		}

		public Double AsNumber() => _valueType switch
		{
			ValueType.Boolean or ValueType.Number => _number,
			var _ => 0.0,
		};

		public String AsString() => _valueType switch
		{
			ValueType.Boolean or ValueType.Number => _number.ToString(),
			ValueType.String => _string ?? String.Empty,
			var _ => String.Empty,
		};

		public Boolean AsBoolean() => _valueType switch
		{
			ValueType.Boolean or ValueType.Number => _number != 0,
			var _ => false,
		};

		public void Set(Double number)
		{
			_valueType = ValueType.Number;
			_number = number;
		}

		public void Set(Boolean truthValue)
		{
			_valueType = ValueType.Boolean;
			_number = truthValue ? 1 : 0;
		}

		public void Set(String text)
		{
			_valueType = ValueType.String;
			_string = text;
		}

		// Increment numeric values (Boolean treated as 1/0). No-op if non-numeric (e.g., String).
		public void Increment(Double amount)
		{
			if (IsNumeric)
				_number += amount;
		}

		public void Increment(Variable amount) => Increment(amount.AsNumber());

		public override String ToString() => _valueType switch
		{
			ValueType.Boolean => $"Boolean({_number != 0})",
			ValueType.Number => $"Number({_number})",
			ValueType.String => $"String({_string ?? String.Empty})",
			var _ => "Nil()",
		};

		public static implicit operator Variable(Int32 v) => new(v);
		public static implicit operator Variable(Single v) => new(v);
		public static implicit operator Variable(Double v) => new(v);
		public static implicit operator Variable(Boolean v) => new(v);
		public static implicit operator Variable(String v) => new(v);

		// Arithmetic operators (numeric-only). If any operand is non-numeric, left operand is returned unchanged.
		public static Variable operator +(Variable a, Variable b) => a.IsNumeric && b.IsNumeric ? new Variable(a.AsNumber() + b.AsNumber()) : a;
		public static Variable operator -(Variable a, Variable b) => a.IsNumeric && b.IsNumeric ? new Variable(a.AsNumber() - b.AsNumber()) : a;
		public static Variable operator *(Variable a, Variable b) => a.IsNumeric && b.IsNumeric ? new Variable(a.AsNumber() * b.AsNumber()) : a;
		public static Variable operator /(Variable a, Variable b) => a.IsNumeric && b.IsNumeric ? new Variable(a.AsNumber() / b.AsNumber()) : a;
		public static Variable operator %(Variable a, Variable b) => a.IsNumeric && b.IsNumeric ? new Variable(a.AsNumber() % b.AsNumber()) : a;

		public static Variable operator +(Variable a, Double b) => a.IsNumeric ? new Variable(a.AsNumber() + b) : a;
		public static Variable operator -(Variable a, Double b) => a.IsNumeric ? new Variable(a.AsNumber() - b) : a;
		public static Variable operator *(Variable a, Double b) => a.IsNumeric ? new Variable(a.AsNumber() * b) : a;
		public static Variable operator /(Variable a, Double b) => a.IsNumeric ? new Variable(a.AsNumber() / b) : a;
		public static Variable operator %(Variable a, Double b) => a.IsNumeric ? new Variable(a.AsNumber() % b) : a;

		public static Variable operator +(Double a, Variable b) => b.IsNumeric ? new Variable(a + b.AsNumber()) : b;
		public static Variable operator -(Double a, Variable b) => b.IsNumeric ? new Variable(a - b.AsNumber()) : b;
		public static Variable operator *(Double a, Variable b) => b.IsNumeric ? new Variable(a * b.AsNumber()) : b;
		public static Variable operator /(Double a, Variable b) => b.IsNumeric ? new Variable(a / b.AsNumber()) : b;
		public static Variable operator %(Double a, Variable b) => b.IsNumeric ? new Variable(a % b.AsNumber()) : b;

		public static Variable operator +(Variable a) => a;
		public static Variable operator -(Variable a) => a.IsNumeric ? new Variable(-a.AsNumber()) : a;

		// Equality operators (numeric compare for numeric types; string compare for strings)
		public static Boolean operator ==(Variable a, Variable b)
		{
			if (a._valueType == ValueType.String && b._valueType == ValueType.String)
				return String.Equals(a._string ?? String.Empty, b._string ?? String.Empty, StringComparison.Ordinal);

			return a.AsNumber().Equals(b.AsNumber());
		}

		public static Boolean operator !=(Variable a, Variable b) => !(a == b);

		public override Boolean Equals(Object obj) => obj switch
		{
			Variable v => this == v,
			Int32 i => Equals(i),
			Single f => Equals(f),
			Double d => Equals(d),
			Boolean b => Equals(b),
			String s => Equals(s),
			var _ => false,
		};

		public override Int32 GetHashCode() => _valueType switch
		{
			ValueType.String => AsString().GetHashCode(),
			var _ => AsNumber().GetHashCode(),
		};

		// IEquatable implementations
		public Boolean Equals(Variable other) => this == other;
		public Boolean Equals(Int32 other) => IsNumeric && AsNumber().Equals(other);
		public Boolean Equals(Single other) => IsNumeric && AsNumber().Equals(other);
		public Boolean Equals(Double other) => IsNumeric && AsNumber().Equals(other);
		public Boolean Equals(Boolean other) => IsBoolean && AsBoolean().Equals(other);

		public Boolean Equals(String other) =>
			_valueType == ValueType.String && String.Equals(AsString(), other ?? String.Empty, StringComparison.Ordinal);
	}
}
