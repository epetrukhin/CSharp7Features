// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
// ReSharper disable NotAccessedVariable
// ReSharper disable RedundantAssignment
// ReSharper disable UnusedVariable
// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable ArrangeMethodOrOperatorBody

namespace CSharp7Features
{
	internal static class Tuples
	{
		// Нужен NuGet пакет System.ValueTuple

		public static (bool, int) TryParseStringToInt(string str)
		{
			if (int.TryParse(str, out var x))
				return (true, x);

			return (false, 0);

			// return (int.TryParse(str, out var x), x);
		}

		public static void ConsumeTryParse()
		{
			var result = TryParseStringToInt("123");
			if (result.Item1)
				Console.WriteLine(result.Item2);
		}

		public static (int minimum, int maximum) MinMax(int x, int y)
		{
			return (Math.Min(x, y), Math.Max(x, y));
		}

		public static void ConsumeMinMax()
		{
			var result1 = MinMax(120, 21);
			Console.WriteLine(result1.minimum);
			Console.WriteLine(result1.maximum);

			(int min, int max) result2 = MinMax(120, 21);
			Console.WriteLine(result2.min);
			Console.WriteLine(result2.max);

			(int, int) result3 = MinMax(120, 21);
			Console.WriteLine(result3.Item1);
			Console.WriteLine(result3.Item2);
		}

		public static void LongTuples()
		{
			var x = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);
			Debug.Assert(x.Item7 == 7);
			Debug.Assert(x.Rest.Rest.Item5 == 19);
		}

		public static (int min, int max, int count) Stats(IEnumerable<int> xs) // Tuples are mutable
		{
			var result = (min: int.MaxValue, max: int.MinValue, count: 0);

			foreach (var x in xs)
			{
				result.min = Math.Min(result.min, x);
				result.max = Math.Max(result.max, x);
				result.count++;
			}

			if (result.count == 0)
				throw new ArgumentException("xs is empty");

			return result;
		}

		public static void Deconstruct()
		{
			var (min, max, count) = Stats(Enumerable.Range(1, 10));
			(min, _, _) = Stats(Enumerable.Range(1, 100));

			var names = new[]
			{
				"John",
				"Jane",
				"Scott",
				"Michael"
			};
			foreach (var (name, index) in names.Select(ValueTuple.Create<string, int>))
			{
				Console.WriteLine($"{index + 1}. {name}");
			}
		}

		public static void Conversion() // http://mustoverride.com/tuples_conversions/
		{
			// Conversion from tuple literal
			(int x, Func<int, bool> pred) tuple1 = (42, x => x > 0);
			(long x, Predicate<int> pred) tuple2 = (42, x => x > 0);

			// Implicit and Explicit conversions
			(int, string) tuple3 = (42, "foo");
			(double, object) tuple4 = tuple3; // Implicit conversion

			var tuple5 = ((int, string))tuple4; // Explicit conversion

			//var tuple6 = ((string, string))tuple4; // Compile error
		}

		public static void TupleToString()
		{
			var s1 = (1, "qwerty").ToString();			// "(1, qwerty)"
			var s2 = (2, (object)null, 45).ToString();  // "(2, , 45)"
		}

		public static void Equality_GetHashCode()
		{
			var dict = new Dictionary<(int x, int y), string>();
			dict.Add((1, 98), "foo");

			Debug.Assert(dict.ContainsKey((1, 98)));

			//var opEqual = (1, 98) == (1, 98);
		}

		public static void Compare()
		{
			var tuples = new[]
			{
				(100, "a"),
				(5, "x"),
				(5, "a")
			};

			var ordered = tuples
				.OrderBy(t => t)
				.Select(t => t.ToString())
				.ToArray();
		}

		public static void TupleElementNames()
		{
			var dict = new Dictionary<(int x, double y), string>();
			Console.WriteLine(dict.Keys.First().x + dict.Keys.First().y);

			var names = new[]
			{
				"John",
				"Jane",
				"Scott",
				"Michael"
			};
			foreach (var pair in names.Select((name, i) => (name: name, index: i)))
			{
				Console.WriteLine($"{pair.index + 1}. {pair.name}");
			}

			//(int ToString, int GetHashCode, int Equals, int Rest) x = (1, 2, 3, 4);

			(int Item1, int Item2) y = (1, 2);
			//(int Item1, int Item3) z = (1, 2);

			(int foo, string) q = (1, "2");
		}

		public static void RefTuple()
		{
			var refTuple = Tuple.Create("foo", 34, "bar");
			var valueTuple = refTuple.ToValueTuple();
			var refTuple2 = valueTuple.ToTuple();
		}
	}
}