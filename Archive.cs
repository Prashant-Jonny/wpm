
using System;
using System.IO;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;

namespace wpm
{
	
	
	public class Archive
	{
		public static List<string> result;
		
		public Archive()
		{
		}

		public static void Create(string path)
		{
			string dir, tmp, tmp2;
			string packageName = "package.wpx";
			Stack<string> dirStack = new Stack<string>();

			if(File.Exists(packageName))
			{
				File.Delete(packageName);
			}
			
			ZipFile package = ZipFile.Create(packageName);
			package.BeginUpdate();

			string cwd = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(path);

			foreach(string d in Directory.GetDirectories(Directory.GetCurrentDirectory()))
			{
				dirStack.Push(d);
			}

			while(dirStack.Count > 0)
			{
				dir = dirStack.Pop();

				foreach(string file in Directory.GetFiles(dir))
				{
					tmp = file.Remove(0, Directory.GetCurrentDirectory().Length + 1);
					package.Add(tmp);
				}

				foreach(string d in Directory.GetDirectories(dir))
				{
					tmp2 = d.Remove(0, Directory.GetCurrentDirectory().Length + 1);
					package.AddDirectory(tmp2);
					dirStack.Push(tmp2);
				}
			}

			package.CommitUpdate();
			package.Close();

			Directory.SetCurrentDirectory(cwd);
		}
	}
}
