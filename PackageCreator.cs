
using System;

namespace wpm
{
	public class PackageCreator
	{
		private string target;
		private bool validated;
		
		public PackageCreator(string[] args)
		{
			target = "";
			
			if(args.Length < 2)
			{
				Console.WriteLine("Usage: wpm create <directory>");
				return;
			}

			target = args[1];
			validated = false;
		}

		/* Checks if the target directory contains the required information. */
		public bool Validate()
		{
			if(!Validator.ValidateDirectoryStructure(target))
			{
				return false;
			}

			validated = true;
			return true;
		}

		public void Pack()
		{
			if(!validated)
			{
				if(!Validate())
				{
					return;
				}
			}

			Archive.Create(target);
		}
	}
}
