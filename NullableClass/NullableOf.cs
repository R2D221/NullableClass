using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableClass
{
	/// <summary>
	/// Represents a reference type that can be assigned `null`.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[DebuggerDisplay("{value}")]
	public struct NullableOf<T> : IEquatable<NullableOf<T>>
		where T : class
	{
		private readonly T value;

		public NullableOf(T value)
		{
			this.value = value;
		}

		public bool HasValue => value != null;

		public T Value => value ?? throw new InvalidOperationException("Nullable object must have a value");

		public T GetValueOrDefault() => value ?? Default<T>.Get();
		public T GetValueOrDefault(T defaultValue) => value ?? defaultValue;

		private static bool Equals(NullableOf<T> left, NullableOf<T> right)
		{
			return
				left.HasValue != right.HasValue ? false :
				!left.HasValue ? true :
				EqualityComparer<T>.Default.Equals(left.value, right.value);
		}

		public override bool Equals(object obj)
		{
			// It's not recommended to use Equals(object), and this will most likely only be called by legacy code.
			// We provide an implementation that strives to be reflexive, symmetric and transitive,
			// which means a comparison between a nullable type and a non-nullable type must return false,
			// since the Equals method from the non-nullable type doesn't take the nullable type into account.

			switch (obj)
			{
				// We shouldn't be getting nulls if we're using the analyzer as well
				case null: throw new NullReferenceException();
				case NullableOf<T> that: return Equals(this, that);
				default: return false;
			}
		}

		public bool Equals(NullableOf<T> that)
		{
			return Equals(this, that);
		}

		public static bool operator ==(NullableOf<T> left, NullableOf<T> right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(NullableOf<T> left, NullableOf<T> right)
		{
			return !Equals(left, right);
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
