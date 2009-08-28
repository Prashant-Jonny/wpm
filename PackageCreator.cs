
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
				Console.WriteLine("Error: directory " + target + " does not contain a 'data' directory.");
				return false;
			}

			/* Check if the target contains the 'metadata' directory. */
			if(!((IList<string>)dirContents).Contains(target + "/metadata"))
			{
				Console.WriteLine("Error: directory " + target + " does not contain a 'metadata' directory.");
				return false;
			}

			dirContents = Directory.GetFiles(target + "/metadata");

			/* Check if the target contains the metadata.xml file. */
			if(!((IList<string>)dirContents).Contains(target + "/metadata/metadata.xml"))
			{
				Console.WriteLine("Error: file " + target + "/metadata/metadata.xml does not exist.");
				return false;
			}

			dirContents = Directory.GetFiles(target + "/data");

			/* Check if the data directory is empty. */
			if(dirContents.Length == 0)
			{
				Console.WriteLine("Error: the data directory is empty.");
				return false;
			}
			
			return true;
		}

		public void Pack()
		{

		}
	}
}
