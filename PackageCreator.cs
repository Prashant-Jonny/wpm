
using System;

namespace wpm
{
	public class PackageCreator
	{
		private string directory;
		private string outputFile;
		private bool validated;
		
		public PackageCreator(string[] args)
		{
			directory = "";
			
			if(args.Length < 3)
			{
				Console.WriteLine("Usage: wpm create <directory> <filename>.wpx");
				return;
			}

			directory = args[1];
			outputFile = args[2];
			validated = false;
		}

		/* Checks if the target directory contains the required information. */
		public bool Validate()
		{
			if(!Validator.ValidateDirectoryStructure(directory))
			{
				validated = false;
				return false;
			}

			if(!Validator.ValidateMetadata())
			{
				validated = false;
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

			Archive.Create(directory, outputFile);
		}
	}
}
