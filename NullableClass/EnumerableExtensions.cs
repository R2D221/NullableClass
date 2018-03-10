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
		public static IEnumerable<TSource> DefaultIfEmpty_<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default(RequireClass<TSource>))
			where TSource : class
		{
			return source.DefaultIfEmpty(Default<TSource>.Get());
		}
		public static IEnumerable<TSource> DefaultIfEmpty_<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default(RequireStruct<TSource>))
			where TSource : struct
		{
			return source.DefaultIfEmpty(default(TSource));
		}
		public static IEnumerable<NullableOf<TSource>> DefaultIfEmpty_<TSource>(this IEnumerable<NullableOf<TSource>> source)
			where TSource : class
		{
			return source.DefaultIfEmpty(null);
		}
		public static IEnumerable<Nullable<TSource>> DefaultIfEmpty_<TSource>(this IEnumerable<Nullable<TSource>> source)
			where TSource : struct
		{
			return source.DefaultIfEmpty(null);
		}
		
		public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index)
		{
			throw new NotImplementedException();
		}
		public static TSource ElementAtOrDefault_<TSource>(this IEnumerable<TSource> source, int index, RequireClass<TSource> _ = default(RequireClass<TSource>))
			where TSource : class
		{
			return Enumerable.ElementAtOrDefault(source, index) ?? Default<TSource>.Get();
		}
		public static TSource ElementAtOrDefault_<TSource>(this IEnumerable<TSource> source, int index, RequireStruct<TSource> _ = default(RequireStruct<TSource>))
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

		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			throw new NotImplementedException();
		}
		public static TSource FirstOrDefault_<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default(RequireClass<TSource>))
			where TSource : class
		{
			return Enumerable.FirstOrDefault(source) ?? Default<TSource>.Get();
		}
		public static TSource FirstOrDefault_<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default(RequireStruct<TSource>))
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
		
		public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			throw new NotImplementedException();
		}
		public static TSource LastOrDefault_<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default(RequireClass<TSource>))
			where TSource : class
		{
			return Enumerable.LastOrDefault(source) ?? Default<TSource>.Get();
		}
		public static TSource LastOrDefault_<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default(RequireStruct<TSource>))
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
		
		public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			throw new NotImplementedException();
		}
		public static TSource SingleOrDefault_<TSource>(this IEnumerable<TSource> source, RequireClass<TSource> _ = default(RequireClass<TSource>))
			where TSource : class
		{
			return Enumerable.SingleOrDefault(source) ?? Default<TSource>.Get();
		}
		public static TSource SingleOrDefault_<TSource>(this IEnumerable<TSource> source, RequireStruct<TSource> _ = default(RequireStruct<TSource>))
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

		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			throw new NotImplementedException();
		}
		public static TSource FirstOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireClass<TSource> _ = default(RequireClass<TSource>))
			where TSource : class
		{
			return Enumerable.FirstOrDefault(source, predicate) ?? Default<TSource>.Get();
		}
		public static TSource FirstOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireStruct<TSource> _ = default(RequireStruct<TSource>))
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

		public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			throw new NotImplementedException();
		}
		public static TSource LastOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireClass<TSource> _ = default(RequireClass<TSource>))
			where TSource : class
		{
			return Enumerable.LastOrDefault(source, predicate) ?? Default<TSource>.Get();
		}
		public static TSource LastOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireStruct<TSource> _ = default(RequireStruct<TSource>))
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

		public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			throw new NotImplementedException();
		}
		public static TSource SingleOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireClass<TSource> _ = default(RequireClass<TSource>))
			where TSource : class
		{
			return Enumerable.SingleOrDefault(source, predicate) ?? Default<TSource>.Get();
		}
		public static TSource SingleOrDefault_<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, RequireStruct<TSource> _ = default(RequireStruct<TSource>))
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
	}
}