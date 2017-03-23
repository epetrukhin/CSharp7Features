// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeMethodOrOperatorBody
// ReSharper disable UnusedParameter.Local
#pragma warning disable 1998

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp7Features
{
	internal sealed class Value_Task
	{
		// Нужен NuGet пакет System.Threading.Tasks.Extensions

		private readonly Dictionary<string, int> cache = new Dictionary<string, int>();

		public async ValueTask<int> GetDataCSharp7(string from)
		{
			int result;
			if (cache.TryGetValue(from, out result))
				return result;

			result = await GetDataCore(from);
			cache.Add(from, result);
			return result;
		}

		private static async Task<int> GetDataCore(string from)
		{
			// Здесь мы что-то откуда-то достаём

			return 42;
		}
	}
}