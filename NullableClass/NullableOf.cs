using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableClass
{
	internal interface INullableOf
	{
		bool HasValue { get; }
		object Value { get; }
	}

	/// <summary>
	/// Represents a reference type that can be assigned `null`.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[DebuggerDisplay("{value}")]
	public struct NullableOf<T> : INullableOf, IEquatable<NullableOf<T>>, IEquatable<T>
		where T : class
	{
		private readonly T value;

		public NullableOf(T value)
		{
			this.value = value;
		}

		public bool HasValue => value != null;

		public T Value => value ?? throw new InvalidOperationException("Nullable object must have a value");
		object INullableOf.Value => value;

		public T GetValueOrDefault() => value ?? Default<T>.Get();
		public T GetValueOrDefault(T defaultValue) => value ?? defaultValue;

		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case null: return !HasValue;
				case NullableOf<T> x: return Equals(x);
				case T x: return Equals(x);
				case INullableOf x: return HasValue == x.HasValue && (!HasValue || value.Equals(x.Value));
				default: return false;
			}
		}

		public bool Equals(NullableOf<T> obj)
		{
			return HasValue == obj.HasValue && (!HasValue || value.Equals(obj.Value));
		}

		public bool Equals(T obj)
		{
			return HasValue && value.Equals(obj);
		}

		public override int GetHashCode()
		{
			return HasValue ? value.GetHashCode() : 0;
		}

		public override string ToString()
		{
			return HasValue ? value.ToString() : "";
		}

		public static implicit operator NullableOf<T>(T value)
		{
			return new NullableOf<T>(value);
		}

		public static explicit operator T(NullableOf<T> value)
		{
			return value.Value;
		}
	}
}
