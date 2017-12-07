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

	[Obsolete("Special class for generic type resolution. Don't use directly")]
	public sealed class RequireStruct<T> where T : struct { }
	[Obsolete("Special class for generic type resolution. Don't use directly")]
	public sealed class RequireClass<T> where T : class { }

#pragma warning disable CS0618
	public static class NullableExtensions
	{
		public static NullableOf<TResult> Select<T, TResult>(this NullableOf<T> @this, Func<T, TResult> func, RequireClass<TResult> _ = null)
			where T : class
			where TResult : class
		{
			return @this.HasValue ? func((T)@this) : default(NullableOf<TResult>);
		}
		public static Nullable<TResult> Select<T, TResult>(this NullableOf<T> @this, Func<T, TResult> func, RequireStruct<TResult> _ = null)
			where T : class
			where TResult : struct
		{
			return @this.HasValue ? func((T)@this) : default(Nullable<TResult>);
		}
		public static NullableOf<TResult> Select<T, TResult>(this Nullable<T> @this, Func<T, TResult> func, RequireClass<TResult> _ = null)
			where T : struct
			where TResult : class
		{
			return @this.HasValue ? func((T)@this) : default(NullableOf<TResult>);
		}
		public static Nullable<TResult> Select<T, TResult>(this Nullable<T> @this, Func<T, TResult> func, RequireStruct<TResult> _ = null)
			where T : struct
			where TResult : struct
		{
			return @this.HasValue ? func((T)@this) : default(Nullable<TResult>);
		}

		public static NullableOf<TResult> SelectMany<T, TMid, TResult>(this NullableOf<T> @this, Func<T, NullableOf<TMid>> midSelector, Func<T, TMid, TResult> resultSelector, RequireClass<TResult> _ = null)
			where T : class
			where TMid : class
			where TResult : class
		{
			if (!@this.HasValue) return default(NullableOf<TResult>);
			var mid = midSelector((T)@this);
			if (!mid.HasValue) return default(NullableOf<TResult>);
			return resultSelector((T)@this, (TMid)mid);
		}
		public static Nullable<TResult> SelectMany<T, TMid, TResult>(this NullableOf<T> @this, Func<T, NullableOf<TMid>> midSelector, Func<T, TMid, TResult> resultSelector, RequireStruct<TResult> _ = null)
			where T : class
			where TMid : class
			where TResult : struct
		{
			if (!@this.HasValue) return default(Nullable<TResult>);
			var mid = midSelector((T)@this);
			if (!mid.HasValue) return default(Nullable<TResult>);
			return resultSelector((T)@this, (TMid)mid);
		}
		public static NullableOf<TResult> SelectMany<T, TMid, TResult>(this NullableOf<T> @this, Func<T, Nullable<TMid>> midSelector, Func<T, TMid, TResult> resultSelector, RequireClass<TResult> _ = null)
			where T : class
			where TMid : struct
			where TResult : class
		{
			if (!@this.HasValue) return default(NullableOf<TResult>);
			var mid = midSelector((T)@this);
			if (!mid.HasValue) return default(NullableOf<TResult>);
			return resultSelector((T)@this, (TMid)mid);
		}
		public static Nullable<TResult> SelectMany<T, TMid, TResult>(this NullableOf<T> @this, Func<T, Nullable<TMid>> midSelector, Func<T, TMid, TResult> resultSelector, RequireStruct<TResult> _ = null)
			where T : class
			where TMid : struct
			where TResult : struct
		{
			if (!@this.HasValue) return default(Nullable<TResult>);
			var mid = midSelector((T)@this);
			if (!mid.HasValue) return default(Nullable<TResult>);
			return resultSelector((T)@this, (TMid)mid);
		}
		public static NullableOf<TResult> SelectMany<T, TMid, TResult>(this Nullable<T> @this, Func<T, NullableOf<TMid>> midSelector, Func<T, TMid, TResult> resultSelector, RequireClass<TResult> _ = null)
			where T : struct
			where TMid : class
			where TResult : class
		{
			if (!@this.HasValue) return default(NullableOf<TResult>);
			var mid = midSelector((T)@this);
			if (!mid.HasValue) return default(NullableOf<TResult>);
			return resultSelector((T)@this, (TMid)mid);
		}
		public static Nullable<TResult> SelectMany<T, TMid, TResult>(this Nullable<T> @this, Func<T, NullableOf<TMid>> midSelector, Func<T, TMid, TResult> resultSelector, RequireStruct<TResult> _ = null)
			where T : struct
			where TMid : class
			where TResult : struct
		{
			if (!@this.HasValue) return default(Nullable<TResult>);
			var mid = midSelector((T)@this);
			if (!mid.HasValue) return default(Nullable<TResult>);
			return resultSelector((T)@this, (TMid)mid);
		}
		public static NullableOf<TResult> SelectMany<T, TMid, TResult>(this Nullable<T> @this, Func<T, Nullable<TMid>> midSelector, Func<T, TMid, TResult> resultSelector, RequireClass<TResult> _ = null)
			where T : struct
			where TMid : struct
			where TResult : class
		{
			if (!@this.HasValue) return default(NullableOf<TResult>);
			var mid = midSelector((T)@this);
			if (!mid.HasValue) return default(NullableOf<TResult>);
			return resultSelector((T)@this, (TMid)mid);
		}
		public static Nullable<TResult> SelectMany<T, TMid, TResult>(this Nullable<T> @this, Func<T, Nullable<TMid>> midSelector, Func<T, TMid, TResult> resultSelector, RequireStruct<TResult> _ = null)
			where T : struct
			where TMid : struct
			where TResult : struct
		{
			if (!@this.HasValue) return default(Nullable<TResult>);
			var mid = midSelector((T)@this);
			if (!mid.HasValue) return default(Nullable<TResult>);
			return resultSelector((T)@this, (TMid)mid);
		}
	}
#pragma warning restore CS0618
}
