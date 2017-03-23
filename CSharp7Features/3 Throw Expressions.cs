// ReSharper disable ArrangeConstructorOrDestructorBody
// ReSharper disable ArrangeMethodOrOperatorBody
// ReSharper disable NotAccessedField.Local
// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;

namespace CSharp7Features
{
	internal sealed class ThrowExpressions
	{
		private readonly string value;

		public ThrowExpressions(string value)
		{
			this.value = value ?? throw new ArgumentNullException(nameof(value));
		}

		public T GetSecond<T>(IReadOnlyList<T> list)
		{
			return list.Count >= 2
				? list[1]
				: throw new ArgumentException();
		}

		public void NotImplemented() => throw new NotImplementedException();
	}
}