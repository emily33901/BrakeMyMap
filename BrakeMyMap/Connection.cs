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
		private string targetEntity;
		private string input;
		private float delay;
		private int timesToFire;
		private string parameter;

		public bool IsInstance { get; set; }

		// the output name from the entity aka "OnTrigger"
		// should contain the "instance:entityname" aswell as the actual trigger
		public string Output
		{
			get { return output; }
			set
			{
				output = value;
				UpdateTree();
			}
		}

		public string TargetEntity
		{
			get { return targetEntity; }
			set
			{
				targetEntity = value;
				UpdateTree();
			}
		}

		public string Input
		{
			get { return input; }
			set
			{
				input = value;
				UpdateTree();
			}
		}

		public float Delay
		{
			get { return delay; }
			set
			{
				delay = value;
				UpdateTree();
			}
		}

		public int TimesToFire
		{
			get { return timesToFire; }
			set
			{
				timesToFire = value;
				UpdateTree();
			}
		}

		public string Parameter
		{
			get { return parameter; }
			set
			{
				parameter = value;
				UpdateTree();
			}
		}

		public Connection(VProperty val)
		{
			connection = val;
			output = val.Key;
			// TODO: this split token can change per engine version
			string[] parts = val.Value.ToString().Split('\x1b');


			// parse the input
			TargetEntity = parts[0];
			input = parts[1];
			parameter = parts[2];
			delay = float.Parse(parts[3]);
			timesToFire = int.Parse(parts[4]);

		}

		private void UpdateTree()
		{
			connection.Key = Output;

			connection.Value.ToVValue().Value = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}", '\x1b', TargetEntity, input,
				parameter, delay, timesToFire);
		}
	}
}
