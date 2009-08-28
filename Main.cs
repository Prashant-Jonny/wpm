using System;

namespace wpm
{
	class MainClass
	{
		private static void PrintHelp()
		{
			Console.WriteLine("Whitix Package Manager v0.3\n");
			Console.WriteLine("Options:");
			Console.WriteLine("\tinstall - Install a package");
			Console.WriteLine("\tupdate - Update the database with available packages");
			Console.WriteLine("\tremove - Remove a package from the system");
			Console.WriteLine("\tcreate - Create a package from a directory");
		}
		
		public static void Main(string[] args)
		{		
			if(args.Length < 1)
			{
				PrintHelp();
				return;
			}

			switch(args[0])
			{
				case "create":
					PackageCreator creator = new PackageCreator(args);

					if(creator.Validate())
					{
						creator.Pack();
					}
					break;
				
				default:
					PrintHelp();
					break;
			}
		}
	}
}