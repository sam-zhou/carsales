using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Carsales.Core.Enum
{
    [DebuggerDisplay("LookupData {Name}")]
	internal class LookupData
	{
		public string Name { get; set; }
		public IEnumerable<LookupValue> Values { get; set; }
		public Type NumericType { get; set; }
	}
}