using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Database
{
	[Serializable]
	public class ConnectionFailedException : Exception
	{
		private const string _message = "Cannot establish a connection with the current connection string.";

		public ConnectionFailedException(string connectionString)
			: base(_message)
		{
			ConnectionString = connectionString;

		}

		public string ConnectionString { get; private set; }
	}
}
