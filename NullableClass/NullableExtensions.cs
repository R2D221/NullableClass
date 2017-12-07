using System;
using System.Collections.Generic;
using System.Text;

namespace NullableClass
{

	public sealed class RequireStruct<T> where T : struct { private RequireStruct() { } }
	public sealed class RequireClass<T> where T : class { private RequireClass() { } }

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
}
