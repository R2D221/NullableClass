using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullableClass
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source)
		{
			throw new NotImplementedException();
		}
		public static IEnumerable<NullableOf<TSource>> NullIfEmpty<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return source.Select(x => (NullableOf<TSource>)x).DefaultIfEmpty(null);
		}
		public static IEnumerable<Nullable<TSource>> NullIfEmpty<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return source.Select(x => (Nullable<TSource>)x).DefaultIfEmpty(null);
		}

		public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index)
		{
			throw new NotImplementedException();
		}
		public static TSource ElementAtOrDefault_<TSource>(this IEnumerable<TSource> source, int index, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.ElementAtOrDefault(source, index) ?? Default<TSource>.Get();
		}
		public static TSource ElementAtOrDefault_<TSource>(this IEnumerable<TSource> source, int index, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.ElementAtOrDefault(source, index);
		}
		public static NullableOf<TSource> ElementAtOrDefault_<TSource>(this IEnumerable<NullableOf<TSource>> source, int index)
			where TSource : class
		{
			return Enumerable.ElementAtOrDefault(source, index);
		}
		public static Nullable<TSource> ElementAtOrDefault_<TSource>(this IEnumerable<Nullable<TSource>> source, int index)
			where TSource : struct
		{
			return Enumerable.ElementAtOrDefault(source, index);
		}
		public static NullableOf<TSource> ElementAtOrNull<TSource>(this IEnumerable<TSource> source, int index, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.ElementAtOrDefault(source.Select(x => (NullableOf<TSource>)x), index);
		}
		public static Nullable<TSource> ElementAtOrNull<TSource>(this IEnumerable<TSource> source, int index, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.ElementAtOrDefault(source.Select(x => (Nullable<TSource>)x), index);
		}

		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			throw new NotImplementedException();
		}
		public static TSource FirstOrDefault_<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.FirstOrDefault(source) ?? Default<TSource>.Get();
		}
		public static TSource FirstOrDefault_<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.FirstOrDefault(source);
		}
		public static NullableOf<TSource> FirstOrDefault_<TSource>(this IEnumerable<NullableOf<TSource>> source)
			where TSource : class
		{
			return Enumerable.FirstOrDefault(source);
		}
		public static Nullable<TSource> FirstOrDefault_<TSource>(this IEnumerable<Nullable<TSource>> source)
			where TSource : struct
		{
			return Enumerable.FirstOrDefault(source);
		}
		public static NullableOf<TSource> FirstOrNull<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.FirstOrDefault(source.Select(x => (NullableOf<TSource>)x));
		}
		public static Nullable<TSource> FirstOrNull<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.FirstOrDefault(source.Select(x => (Nullable<TSource>)x));
		}

		public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			throw new NotImplementedException();
		}
		public static TSource LastOrDefault_<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.LastOrDefault(source) ?? Default<TSource>.Get();
		}
		public static TSource LastOrDefault_<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.LastOrDefault(source);
		}
		public static NullableOf<TSource> LastOrDefault_<TSource>(this IEnumerable<NullableOf<TSource>> source)
			where TSource : class
		{
			return Enumerable.LastOrDefault(source);
		}
		public static Nullable<TSource> LastOrDefault_<TSource>(this IEnumerable<Nullable<TSource>> source)
			where TSource : struct
		{
			return Enumerable.LastOrDefault(source);
		}
		public static NullableOf<TSource> LastOrNull<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.LastOrDefault(source.Select(x => (NullableOf<TSource>)x));
		}
		public static Nullable<TSource> LastOrNull<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.LastOrDefault(source.Select(x => (Nullable<TSource>)x));
		}

		public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			throw new NotImplementedException();
		}
		public static TSource SingleOrDefault_<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.SingleOrDefault(source) ?? Default<TSource>.Get();
		}
		public static TSource SingleOrDefault_<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.SingleOrDefault(source);
		}
		public static NullableOf<TSource> SingleOrDefault_<TSource>(this IEnumerable<NullableOf<TSource>> source)
			where TSource : class
		{
			return Enumerable.SingleOrDefault(source);
		}
		public static Nullable<TSource> SingleOrDefault_<TSource>(this IEnumerable<Nullable<TSource>> source)
			where TSource : struct
		{
			return Enumerable.SingleOrDefault(source);
		}
		public static NullableOf<TSource> SingleOrNull<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.SingleOrDefault(source.Select(x => (NullableOf<TSource>)x));
		}
		public static Nullable<TSource> SingleOrNull<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.SingleOrDefault(source.Select(x => (Nullable<TSource>)x));
		}

		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			throw new NotImplementedException();
		}
		public static TSource FirstOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.FirstOrDefault(source, predicate) ?? Default<TSource>.Get();
		}
		public static TSource FirstOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.FirstOrDefault(source, predicate);
		}
		public static NullableOf<TSource> FirstOrDefault_<TSource>(this IEnumerable<NullableOf<TSource>> source, Func<NullableOf<TSource>, bool> predicate)
			where TSource : class
		{
			return Enumerable.FirstOrDefault(source, predicate);
		}
		public static Nullable<TSource> FirstOrDefault_<TSource>(this IEnumerable<Nullable<TSource>> source, Func<Nullable<TSource>, bool> predicate)
			where TSource : struct
		{
			return Enumerable.FirstOrDefault(source, predicate);
		}
		public static NullableOf<TSource> FirstOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return source.Where(predicate).FirstOrNull();
		}
		public static Nullable<TSource> FirstOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return source.Where(predicate).FirstOrNull();
		}

		public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			throw new NotImplementedException();
		}
		public static TSource LastOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.LastOrDefault(source, predicate) ?? Default<TSource>.Get();
		}
		public static TSource LastOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.LastOrDefault(source, predicate);
		}
		public static NullableOf<TSource> LastOrDefault_<TSource>(this IEnumerable<NullableOf<TSource>> source, Func<NullableOf<TSource>, bool> predicate)
			where TSource : class
		{
			return Enumerable.LastOrDefault(source, predicate);
		}
		public static Nullable<TSource> LastOrDefault_<TSource>(this IEnumerable<Nullable<TSource>> source, Func<Nullable<TSource>, bool> predicate)
			where TSource : struct
		{
			return Enumerable.LastOrDefault(source, predicate);
		}
		public static NullableOf<TSource> LastOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return source.Where(predicate).LastOrNull();
		}
		public static Nullable<TSource> LastOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return source.Where(predicate).LastOrNull();
		}

		public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			throw new NotImplementedException();
		}
		public static TSource SingleOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return Enumerable.SingleOrDefault(source, predicate) ?? Default<TSource>.Get();
		}
		public static TSource SingleOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return Enumerable.SingleOrDefault(source, predicate);
		}
		public static NullableOf<TSource> SingleOrDefault_<TSource>(this IEnumerable<NullableOf<TSource>> source, Func<NullableOf<TSource>, bool> predicate)
			where TSource : class
		{
			return Enumerable.SingleOrDefault(source, predicate);
		}
		public static Nullable<TSource> SingleOrDefault_<TSource>(this IEnumerable<Nullable<TSource>> source, Func<Nullable<TSource>, bool> predicate)
			where TSource : struct
		{
			return Enumerable.SingleOrDefault(source, predicate);
		}
		public static NullableOf<TSource> SingleOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireClass<TSource> _ = default)
			where TSource : class
		{
			return source.Where(predicate).SingleOrNull();
		}
		public static Nullable<TSource> SingleOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireStruct<TSource> _ = default)
			where TSource : struct
		{
			return source.Where(predicate).SingleOrNull();
		}
	}
}