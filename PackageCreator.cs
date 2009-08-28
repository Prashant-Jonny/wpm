
using System;
using System.IO;
using System.Collections.Generic;

namespace wpm
{
	
	
	public class PackageCreator
	{
		private string target;
		
		public PackageCreator(string[] args)
		{
			target = "";
			
			if(args.Length < 2)
			{
				Console.WriteLine("Usage: wpm create <directory>");
				return;
			}

			target = args[1];
		}

		/* Checks if the target directory contains the required information. */
		public bool Validate()
		{
			/* Check if the target directory exists. */
			if(!Directory.Exists(target))
			{
				Console.WriteLine("Error: directory " + target + " does not exist.");
				return false;
			}

			string[] dirContents = Directory.GetDirectories(target);

			/* Check if the target contains the 'data' directory. */
			if(!((IList<string>)dirContents).Contains(target + "/data"))
			{
				System.Console.WriteLine("Error: directory " + target + " does not contain a 'data' directory.");
				return false;
			}

			/* Check if the target contains the 'metadata' directory. */
			if(!((IList<string>)dirContents).Contains(target + "/metadata"))
			{
				System.Console.WriteLine("Error: directory " + target + " does not contain a 'metadata' directory.");
				return false;
			}
			
			return true;
		}

		public void Pack()
		{

		}
	}
}
