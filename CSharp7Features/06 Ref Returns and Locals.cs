// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

using System;
using System.Collections.Generic;

namespace CSharp7Features
{
	internal static class RefReturnsAndLocals
	{
		private static int FindIndex<T>(T value, T[] data)
		{
			var comparer = EqualityComparer<T>.Default;

			for (var i = 0; i < data.Length; i++)
			{
				var item = data[i];
				if (comparer.Equals(item, value))
					return i;
			}

			throw new IndexOutOfRangeException();
		}

		private static void CSharp6()
		{
			var data = new[] { "1", "2", "3" };
			var index = FindIndex("2", data);
			data[index] = "42"; // data: { 1, 42, 3 }
		}

		private static ref T Find<T>(T value, T[] data)
		{
			var comparer = EqualityComparer<T>.Default;

			for (var i = 0; i < data.Length; i++)
			{
				ref var item = ref data[i];
				if (comparer.Equals(item, value))
					return ref item;
			}

			throw new IndexOutOfRangeException();
		}

		public static void CSharp7()
		{
			var data = new[] { "1", "2", "3" };
			ref var index = ref Find("2", data); // Если убрать оба ref, то работать не будет
			index = "42"; // data: { 1, 42, 3 }
		}

//		private static ref int DoNotCompiled()
//		{
//			var x = 42;
//			return ref x;
//
////			var xs = new[] { 1, 2, 3 };
////			return ref xs[1];
//		}

		private sealed class Foo
		{
			private /*readonly*/ bool field;

			public ref bool GetField() => ref field;
		}
	}
}