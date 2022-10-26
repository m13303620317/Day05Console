using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day05Console
{
    internal class CurrentDirectory { }
    internal class Program
    {
        //private static void Init()
        //{
        //    Console.WriteLine("Welcome to access the file program!");
        //    Console.WriteLine("-----------------------------------\n\n");
        //    Console.WriteLine(@"The current position is: C:\");

        //    // Show directories and files in the current position.
        //    DirectoryInfo Folder = new DirectoryInfo(@"C:\");
        //    foreach (DirectoryInfo di in Folder.GetDirectories())
        //    {
        //        Console.WriteLine($"Directory {di.Name}");
        //    }
        //    foreach (FileInfo fi in Folder.GetFiles())
        //    {
        //        Console.WriteLine($"File {fi.Name}");
        //    }
        //}

        private static void CreateFile(string currentDirectory)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Please put down a file name:");
                string fileName = Console.ReadLine();
                try
                {
                    if (!File.Exists($@"{currentDirectory}\{fileName}"))
                    {
                        // Create a file
                        File.Create($@"{currentDirectory}\{fileName}");
                        Console.WriteLine("The file is successfully created!");
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("The file already exists!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void CopyFile(string currentDirectory)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Please put down a file name:");
                // Which file you want to copy
                string fileName = Console.ReadLine();
                try
                {
                    if (File.Exists($@"{currentDirectory}\{fileName}"))
                    {
                        // Where you want to copy
                        Console.WriteLine("Please put down a directory where you want to copy:");
                        string directory = Console.ReadLine();
                        while (!Directory.Exists(directory))
                        {
                            Console.WriteLine("Please put down a directory where you want to copy:");
                            directory = Console.ReadLine();
                        }
                        // Copy a file
                        File.Copy($@"{currentDirectory}\{fileName}", $@"{directory}\{fileName}");
                        Console.WriteLine("The file is successfully copied!");
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("The file doesn't exist!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void MoveFile(string currentDirectory)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Please put down a file name:");
                // Which file you want to move
                string fileName = Console.ReadLine();
                try
                {
                    if (File.Exists($@"{currentDirectory}\{fileName}"))
                    {
                        // Where you want to move
                        Console.WriteLine("Please put down a directory where you want to move:");
                        string directory = Console.ReadLine();
                        while (!Directory.Exists(directory))
                        {
                            Console.WriteLine("Please put down a directory where you want to move:");
                            directory = Console.ReadLine();
                        }
                        // Create a file and delete the current file
                        File.Copy($@"{currentDirectory}\{fileName}", $@"{directory}\{fileName}");
                        File.Delete($@"{currentDirectory}\{fileName}");
                        Console.WriteLine("The file is successfully move!");
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("The file doesn't exist!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static string JumpTo()
        {
            bool exit = false;
            string directory = "";
            while (!exit)
            {
                Console.WriteLine("Please put down a directory:");
                directory = Console.ReadLine();

                if (Directory.Exists(directory))
                {
                    Console.WriteLine($"The current position is: {directory}");
                    // Show directories and files in the current position.
                    DirectoryInfo Folder = new DirectoryInfo(directory);
                    foreach (DirectoryInfo di in Folder.GetDirectories())
                    {
                        Console.WriteLine($"Directory {di.Name}");
                    }
                    foreach (FileInfo fi in Folder.GetFiles())
                    {
                        Console.WriteLine($"File {fi.Name}");
                    }
                    exit = true;
                }
                else
                {
                    Console.WriteLine("The directory doesn't exist!");
                }
            }
            return directory;
        }

        private static void DeleteFile(string currentDirectory)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Please put down a file name:");
                string fileName = Console.ReadLine();
                try
                {
                    if (File.Exists($@"{currentDirectory}\{fileName}"))
                    {
                        // Delete a file
                        File.Delete($@"{currentDirectory}\{fileName}");
                        Console.WriteLine("The file is successfully deleted!");
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("The file doesn't exist!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        private static async Task<CurrentDirectory> OperateFileBrowserAsync()
        {
            string currentDirectory = @"C:\";

            // Some tips
            Console.WriteLine($"The current position is: {currentDirectory}");

            // Show directories and files in the current position.
            DirectoryInfo Folder = new DirectoryInfo(currentDirectory);
            foreach (DirectoryInfo di in Folder.GetDirectories())
            {
                Console.WriteLine($"Directory {di.Name}");
            }
            foreach (FileInfo fi in Folder.GetFiles())
            {
                Console.WriteLine($"File {fi.Name}");
            }

            Console.WriteLine("\n\nWhat do you want to do?");
            Console.WriteLine("\t-create\tCreate a file");
            Console.WriteLine("\t-copy\tCopy a file");
            Console.WriteLine("\t-move\tMove a file");
            Console.WriteLine("\t-delete\tDelete a file");
            Console.WriteLine("\t-jump\tJump to a directory");


            // Check user's type
            string operate = Console.ReadLine();
            operate = operate.ToLower();
            while (operate != "create" && operate != "copy" && operate != "move" && operate != "delete"
                && operate != "jump")
            {
                Console.WriteLine("What you type is not exist, Please type again.");
                operate = Console.ReadLine();
            }
            switch (operate)
            {
                case "create":
                    await Task.Delay(1000);
                    CreateFile(currentDirectory);
                    break;
                case "copy":
                    await Task.Delay(1000);
                    CopyFile(currentDirectory);
                    break;
                case "move":
                    await Task.Delay(1000);
                    MoveFile(currentDirectory);
                    break;
                case "jump":
                    await Task.Delay(1000);
                    currentDirectory = JumpTo();
                    break;
                case "delete":
                    await Task.Delay(1000);
                    DeleteFile(currentDirectory);
                    break;
                default:
                    Console.WriteLine("Unexpected exception has occured!");
                    break;
            }
            return new CurrentDirectory();
        }

        //private static string OperateFileBrowser(string operate, string currentDirectory)
        //{
        //    switch (operate)
        //    {
        //        case "create":
        //            CreateFile(currentDirectory);
        //            break;
        //        case "copy":
        //            CopyFile(currentDirectory);
        //            break;
        //        case "move":
        //            MoveFile(currentDirectory);
        //            break;
        //        case "jump":
        //            currentDirectory = JumpTo();
        //            break;
        //        case "delete":
        //            DeleteFile(currentDirectory);
        //            break;
        //        default:
        //            Console.WriteLine("Unexpected exception has occured!");
        //            break;
        //    }
        //    return currentDirectory;
        //}
        static async Task Main()
        {
            // Initalize the program. For example, set the starting direcctory to "C:\"
            //Init();

            string currentDirectory = @"C:\";

            bool close = false;
            while(!close)
            {
                //// Some tips
                //Console.WriteLine($"The current position is: {currentDirectory}");

                //// Show directories and files in the current position.
                //DirectoryInfo Folder = new DirectoryInfo(currentDirectory);
                //foreach (DirectoryInfo di in Folder.GetDirectories())
                //{
                //    Console.WriteLine($"Directory {di.Name}");
                //}
                //foreach (FileInfo fi in Folder.GetFiles())
                //{
                //    Console.WriteLine($"File {fi.Name}");
                //}

                //Console.WriteLine("\n\nWhat do you want to do?");
                //Console.WriteLine("\t-create\tCreate a file");
                //Console.WriteLine("\t-copy\tCopy a file");
                //Console.WriteLine("\t-move\tMove a file");
                //Console.WriteLine("\t-delete\tDelete a file");
                //Console.WriteLine("\t-jump\tJump to a directory");


                //// Check user's type
                //string operate = Console.ReadLine();
                //operate = operate.ToLower();
                //while (operate != "create" && operate != "copy" && operate != "move" && operate != "delete"
                //    && operate != "jump")
                //{
                //    Console.WriteLine("What you type is not exist, Please type again.");
                //    operate = Console.ReadLine();
                //}
                //currentDirectory = OperateFileBrowser(operate.ToLower(), currentDirectory);
                await OperateFileBrowserAsync();

                // Continue?
                Console.WriteLine("Continue? (Y/N)");
                string co = Console.ReadLine();
                while (co.ToLower() != "y" && co.ToLower() != "n")
                {
                    Console.WriteLine("Continue? (Y/N)");
                    co = Console.ReadLine();
                }
                if (co.ToLower() == "n")
                {
                    close = true;
                }
            }

            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the Console app...");
            Console.ReadKey();
        }

        
    }
}
