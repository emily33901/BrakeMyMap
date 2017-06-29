using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gameloop.Vdf;

namespace BrakeMyMap
{
	// represents a single connection in the entity
	class Connection
	{
		private VProperty connection;
		private string output;
		private string _event;

		// the output name from the entity aka "OnTrigger"
		public string Output
		{
			get { return output; }
			set { output = value;
				UpdateTree();
			}
		}

		// what happens when this trigger occours
		public string Event
		{
			get { return _event; }
			set
			{
				_event = value;
				UpdateTree();
			}
		}

		public Connection(VProperty val)
		{
			connection = val;
			output = val.Key;
			_event = val.Value.ToString();
		}

		private void UpdateTree()
		{
			connection.Key = Output;
			connection.Value.ToVValue().Value = _event;
		}
	}
}
