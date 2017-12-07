using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableClass
{
	/// <summary>
	/// Represents a reference type that can be assigned `null`.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public struct NullableOf<T> where T : class
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

		public override bool Equals(object otherObject)
		{
			if (otherObject == null) return !HasValue;

			if (otherObject is NullableOf<T>)
			{
				var other = (NullableOf<T>)otherObject;
				return this.HasValue == other.HasValue && (!this.HasValue || this.value.Equals(other.value));
			}

			var otherType = otherObject.GetType();
			if (!otherType.IsConstructedGenericType || otherType.GetGenericTypeDefinition() != typeof(NullableOf<>))
			{
				return HasValue && value.Equals(otherObject);
			}

			return false;
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
