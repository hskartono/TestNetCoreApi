using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCoreApi.Services
{
	public class OperationService : IScopedService, ISingletonService, ITransientService
	{
		private readonly Guid _guid;

		public OperationService()
		{
			_guid = Guid.NewGuid();
		}

		public Guid operationId()
		{
			return _guid;
		}
	}
}
