using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCoreApi
{
	public interface IScopedService
	{
		Guid operationId();
	}
}
