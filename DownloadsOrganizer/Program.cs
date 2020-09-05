using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var downloadsPath = "C:\\Users\\Johnm\\Downloads";
            var picturesDir = "C:\\Users\\Johnm\\Pictures";
            var imageFilePaths = GetImageFilesFromDir(downloadsPath);

            if(imageFilePaths.Count == 0)
            {
                Console.WriteLine("No files to move at this time.");
            }

            // getting whole directory
            foreach(var filePath in imageFilePaths)
            {
                // gets only the file name
                var fileName = Path.GetFileName(filePath);
                var moveToPath = Path.Combine(picturesDir, fileName);

                if (File.Exists(moveToPath))
                {
                    var fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                    var fileExt = Path.GetExtension(filePath);
                    Console.WriteLine("{0} already exists in {1}", fileName, picturesDir);
                    fileName = string.Format("{0}_{1} {2}", moveToPath, Guid.NewGuid(), fileExt);
                    moveToPath = Path.Combine(picturesDir, fileName);

                }

                    
                Console.WriteLine("Moving {0}", fileName);
                File.Move(filePath, moveToPath);
                Console.WriteLine("{0} moved to {1}", fileName, moveToPath);
            }

            Console.ReadLine();


            //foreach(var file in imageFiles)
            //{
            //    Console.WriteLine(file);
            //}

            Console.ReadKey();

        }

        static List<string> GetImageFilesFromDir(string dir)
        {
            var allFilePaths = Directory.GetFiles(dir).ToList();
            var imageFilePaths = new List<string>();

            // for each of the file paths we're iterating over all the file paths
            // convert all extensions to lowercase to standardize
            foreach(var filePath in allFilePaths)
            {
                var fileExt = Path.GetExtension(filePath).ToLower();
                if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".gif" || fileExt == ".bmp")
                    imageFilePaths.Add(filePath);
            }

            return imageFilePaths;
        }
        
        
    }
}


// Making use of Linq methods
// Directory is a key word for C# 
// GetFiles method 
// Path.Combine attaches the file name