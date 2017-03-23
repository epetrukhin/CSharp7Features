﻿// ReSharper disable UnusedVariable
// ReSharper disable RedundantAssignment
// ReSharper disable NotAccessedVariable
// ReSharper disable UnusedMember.Global
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

			(first, last) = person2; // !!! Cannot convert source type 'CSharp7Features.Person' to target type 'string'
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

	public static class PersonExtensions
	{
		public static void Deconstruct(this Person person, out string firstName, out string lastName)
		{
			firstName = person.FirstName;
			lastName = person.LastName;
		}
	}
}