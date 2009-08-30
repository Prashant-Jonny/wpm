
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

			package.BeginUpdate();

			string cwd = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(path);

			string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
			
			foreach(string file in files)
			{
				package.Add(Path.GetFileName(file));
				
			}

			

			package.CommitUpdate();
			package.Close();
		}
	}
}
