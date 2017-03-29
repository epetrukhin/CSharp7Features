// ReSharper disable UnusedVariable
// ReSharper disable RedundantAssignment
// ReSharper disable NotAccessedVariable
// ReSharper disable UnusedMember.Global

using System.Collections.Generic;

namespace CSharp7Features
{
	internal static class Deconstruction
	{
		public static void Deconstruct()
		{
			var person1 = new Person
			{
				FirstName = "John",
				LastName = "Doe",
				Age = 33
			};

			(var first, var last, var age) = person1; // Deconstruct to new variables syntax 1
			var (fN, lN, a) = person1;                // Deconstruct to new variables syntax 2

			(first, last, age) = person1; // Deconstruct to existing variables

			string x, y;
			(x, y, _) = person1; // Discard

			var person2 = new Person
			{
				FirstName = "Jane",
				LastName = "Doe",
				Age = 27
			};

			(first, last) = person2;


			var personAddresses = new Dictionary<Person, string>();
			foreach (var kvp in personAddresses)
			{
				var person = kvp.Key;
				var address = kvp.Value;
			}

			foreach (var (person, address) in personAddresses)
			{

			}

			foreach (var ((pFirstName, pLastName, pAge), address) in personAddresses)
			{

			}
		}
	}

	public sealed class Deconstruct
	{
		public string Prop { get; private set; }
		private string field;

		public void Foo()
		{
			var person = new Person();

			int variable;

			(Prop, field, variable) = person;
		}
	}

	public sealed class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }

		public void Deconstruct(out string firstName, out string lastName, out int age)
		{
			firstName = FirstName;
			lastName = LastName;
			age = Age;
		}
	}

	public static class Extensions
	{
		public static void Deconstruct(this Person person, out string firstName, out string lastName)
		{
			firstName = person.FirstName;
			lastName = person.LastName;
		}

		public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
		{
			key = kvp.Key;
			value = kvp.Value;
		}
	}
}