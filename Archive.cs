
using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace wpm
{
	
	
	public class Archive
	{
		
		public Archive()
		{
		}

		public static void Create(string path)
		{
			string packageName = "package.wpx";
			
			ZipFile package = ZipFile.Create(packageName);
			
			string[] files = Directory.GetFiles(path);

			package.BeginUpdate();
			
			foreach(string file in files)
			{
				package.Add(file);
				System.Console.WriteLine(file);
			}

			package.CommitUpdate();
			package.Close();
		}
	}
}
