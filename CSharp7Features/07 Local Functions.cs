using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace CSharp7Features
{
	internal static class LocalFunctions
	{
		private static void Foo()
		{
			// Helper Method
			PrintHelper("Hello");
			PrintHelper("world");

			// Lambda
			Action<string> print = Console.WriteLine;
			print("Hello");
			print("world");

			// Local Function
			void Print(string s) => Console.WriteLine(s);

			Print("Hello");
			Print("world");

			//void Print(string s) => Console.WriteLine(s);
		}

		private static void PrintHelper(string s) => Console.WriteLine(s);

		private static void Restrictions()
		{
//			[ContractAnnotation("null => null; notnull => notnull")]
//			string Foo([CanBeNull] string s) => s;
		}

		#region Arg Check in Iterators
		public static IEnumerable<T> NotNull<T>(this IEnumerable<T> source) where T : class
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			foreach (var p in NotNullCore(source))
				yield return p;
		}

		private static IEnumerable<T> NotNullCore<T>(IEnumerable<T> source) where T : class
		{
			foreach (var item in source)
			{
				if (item != null)
					yield return item;
			}
		}

		public static IEnumerable<T> NotNullEx<T>(this IEnumerable<T> source) where T : class
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			return NotNullCore();

			IEnumerable<T> NotNullCore()
			{
				foreach (var item in source)
				{
					if (item != null)
						yield return item;
				}
			}
		}
		#endregion

		#region Arg Check in Async Methods
		public static Task<int> CalcSomething(int arg)
		{
			if (arg <= 0)
				throw new ArgumentOutOfRangeException();

			return CalcSomethingCore(arg);
		}

		private static async Task<int> CalcSomethingCore(int arg)
		{
			await Task.Delay(42);
			return arg;
		}

		public static Task<int> CalcSomethingEx(int arg)
		{
			if (arg <= 0)
				throw new ArgumentOutOfRangeException();

			return CalcSomething();

			async Task<int> CalcSomething()
			{
				await Task.Delay(42);
				return arg;
			}
		}
		#endregion

		#region Recursion
		public static int Calc(int x)
		{
			// Lambda
			// Func<int, int> sum = val => val <= 1 ? val : val + sum(val - 1); Не работает
			Func<int, int> sum = null;
			sum = val => val <= 1 ? val : val + sum(val - 1);

			int Sum(int val) => val <= 1 ? val : val + Sum(val - 1);

			return Sum(x);
		}
		#endregion

		#region Generics
		public static void GenericLocalFunc()
		{
			T Id<T>(T x) => x;
		}
		#endregion
	}

	public static class ClosureToValueType
	{
		public static int ToValueType(int x)
		{
			var y = 42;

			int Sum() => x + y;

			return Sum();
		}
	}

	public static class ClosureToRefType
	{
		public static IEnumerable<int> ToRefType(int x)
		{
			bool Filter(int item) => x == item;

			return new[] { 1, 2, 3 }.Where(Filter);
		}
	}
}