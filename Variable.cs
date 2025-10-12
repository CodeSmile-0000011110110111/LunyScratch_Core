using System;
using System.Globalization;

namespace LunyScratch
{
	public enum ValueType
	{
		Null = 0,
		Boolean,
		Number,
		String,
	}

	public sealed class Variable
	{
		// Raised whenever the internal value changes. Emits the current numeric value.
		public event Action<Variable> OnValueChanged;
		private ValueType _valueType;
		private Double _number;
		private String _string;
		private String _name;

		public ValueType ValueType => _valueType;
		public Boolean IsNull => _valueType == ValueType.Null;
		public Boolean IsNumber => _valueType == ValueType.Number;
		public Boolean IsBoolean => _valueType == ValueType.Boolean;
		public Boolean IsString => _valueType == ValueType.String;

		/// <summary>
		/// Optional name for this variable. For dictionary variables, this matches the Table key.
		/// Used as the sole source for GetHashCode to ensure uniqueness per name.
		/// </summary>
		public String Name
		{
			get => _name;
			internal set => _name = value;
		}

		public static implicit operator Variable(Int32 v) => new(v);
		public static implicit operator Variable(Single v) => new(v);
		public static implicit operator Variable(Double v) => new(v);
		public static implicit operator Variable(Boolean v) => new(v);
		public static implicit operator Variable(String v) => new(v);

		// Arithmetic operators (numeric-only). If any operand is non-numeric, left operand is returned unchanged.
		public static Variable operator +(Variable a, Variable b) => a.IsNumber && b.IsNumber ? new Variable(a.AsNumber() + b.AsNumber()) : a;
		public static Variable operator -(Variable a, Variable b) => a.IsNumber && b.IsNumber ? new Variable(a.AsNumber() - b.AsNumber()) : a;
		public static Variable operator *(Variable a, Variable b) => a.IsNumber && b.IsNumber ? new Variable(a.AsNumber() * b.AsNumber()) : a;
		public static Variable operator /(Variable a, Variable b) => a.IsNumber && b.IsNumber ? new Variable(a.AsNumber() / b.AsNumber()) : a;
		public static Variable operator %(Variable a, Variable b) => a.IsNumber && b.IsNumber ? new Variable(a.AsNumber() % b.AsNumber()) : a;

		public static Variable operator +(Variable a, Double b) => a.IsNumber ? new Variable(a.AsNumber() + b) : a;
		public static Variable operator -(Variable a, Double b) => a.IsNumber ? new Variable(a.AsNumber() - b) : a;
		public static Variable operator *(Variable a, Double b) => a.IsNumber ? new Variable(a.AsNumber() * b) : a;
		public static Variable operator /(Variable a, Double b) => a.IsNumber ? new Variable(a.AsNumber() / b) : a;
		public static Variable operator %(Variable a, Double b) => a.IsNumber ? new Variable(a.AsNumber() % b) : a;

		public static Variable operator +(Double a, Variable b) => b.IsNumber ? new Variable(a + b.AsNumber()) : b;
		public static Variable operator -(Double a, Variable b) => b.IsNumber ? new Variable(a - b.AsNumber()) : b;
		public static Variable operator *(Double a, Variable b) => b.IsNumber ? new Variable(a * b.AsNumber()) : b;
		public static Variable operator /(Double a, Variable b) => b.IsNumber ? new Variable(a / b.AsNumber()) : b;
		public static Variable operator %(Double a, Variable b) => b.IsNumber ? new Variable(a % b.AsNumber()) : b;

		public static Variable operator +(Variable a) => a;
		public static Variable operator -(Variable a) => a.IsNumber ? new Variable(-a.AsNumber()) : a;
		public static Boolean operator !=(Variable a, Variable b) => !(a == b);

		public static Boolean operator ==(Variable a, Variable b)
		{
			var aIsNull = ReferenceEquals(a, null);
			var bIsNull = ReferenceEquals(b, null);
			if (aIsNull && bIsNull)
				return true;
			if (aIsNull || bIsNull)
				return false;
			if (a.ValueType != b.ValueType)
				return false;
			if (a._valueType == ValueType.Number && b._valueType == ValueType.Number)
				return a.AsNumber() == b.AsNumber();
			if (a._valueType == ValueType.Boolean && b._valueType == ValueType.Boolean)
				return a.AsBoolean() == b.AsBoolean();
			if (a._valueType == ValueType.String && b._valueType == ValueType.String)
				return String.Equals(a._string, b._string, StringComparison.Ordinal);

			return false;
		}

		public Variable() => _valueType = ValueType.Null;
		public Variable(Variable value) => Set(value);
		public Variable(Double number) => Set(number);
		public Variable(Boolean truthValue) => Set(truthValue);
		public Variable(String text) => Set(text);

		public Double AsNumber() => _valueType switch
		{
			ValueType.Boolean or ValueType.Number => _number,
			var _ => 0.0,
		};

		public Boolean AsBoolean() => _valueType switch
		{
			ValueType.Boolean or ValueType.Number => _number != 0,
			var _ => false,
		};

		public String AsString() => _valueType switch
		{
			ValueType.Boolean or ValueType.Number => _number.ToString(CultureInfo.InvariantCulture),
			ValueType.String => _string ?? String.Empty,
			ValueType.Null => "(null)",
			var _ => throw new ArgumentOutOfRangeException(nameof(_valueType), _valueType.ToString()),
		};

		public void Set(Variable value)
		{
			if (value == null)
			{
				_valueType = ValueType.Null;
				_number = 0;
				_string = null;
				OnValueChanged?.Invoke(this);
			}
			else
			{
				_valueType = value._valueType;
				_number = value._number;
				_string = value._string;
				OnValueChanged?.Invoke(this);
			}
		}

		public void Set(Double number)
		{
			_valueType = ValueType.Number;
			_number = number;
			_string = null;
			OnValueChanged?.Invoke(this);
		}

		public void Set(Boolean truthValue)
		{
			_valueType = ValueType.Boolean;
			_number = truthValue ? 1 : 0;
			_string = null;
			OnValueChanged?.Invoke(this);
		}

		public void Set(String text)
		{
			_valueType = ValueType.String;
			_string = text;
			_number = 0;
			OnValueChanged?.Invoke(this);
		}

		public void Add(Double amount)
		{
			if (IsNumber || IsNull)
				Set(_number + amount);
		}

		public void Add(Variable amount)
		{
			if (amount == null)
				return;

			if (IsNumber || IsNull)
				Set(_number + amount.AsNumber());
			else if (IsString)
				Set(_string + amount.AsString());
		}

		public void Subtract(Double amount)
		{
			if (IsNumber || IsNull)
				Set(_number - amount);
		}

		public void Subtract(Variable amount)
		{
			if (amount == null)
				return;

			if (IsNumber || IsNull)
				Set(_number - amount.AsNumber());
		}

		public override String ToString() => _valueType switch
		{
			ValueType.Boolean => $"Boolean({_number != 0})",
			ValueType.Number => $"Number({_number})",
			ValueType.String => $"String({_string ?? String.Empty})",
			ValueType.Null => "Variable(null)",
			var _ => throw new ArgumentOutOfRangeException(nameof(_valueType), _valueType.ToString()),
		};

		public override Boolean Equals(Object obj) => obj switch
		{
			Variable v => this == v,
			Int32 i => Equals(i),
			Int64 i => Equals(i),
			Single f => Equals(f),
			Double d => Equals(d),
			Boolean b => Equals(b),
			String s => Equals(s),
			var _ => false,
		};

		public override Int32 GetHashCode() => _name == null ? 0 : _name.GetHashCode();

		// IEquatable implementations
		public Boolean Equals(Variable other) => this == other;
		public Boolean Equals(Int32 other) => IsNumber && AsNumber().Equals(other);
		public Boolean Equals(Int64 other) => IsNumber && AsNumber().Equals(other);
		public Boolean Equals(Single other) => IsNumber && AsNumber().Equals(other);
		public Boolean Equals(Double other) => IsNumber && AsNumber().Equals(other);
		public Boolean Equals(Boolean other) => IsBoolean && AsBoolean().Equals(other);

		public Boolean Equals(String other) =>
			_valueType == ValueType.String && String.Equals(AsString(), other ?? String.Empty, StringComparison.Ordinal);
	}
}
