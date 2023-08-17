using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace AfterFormat
{
    class Program
    {
        private static readonly string BaseGitHubLink = "https://raw.githubusercontent.com/redr00t/AfterFormat/main/Files/";
        private static string language = "en-US"; // Por defecto en inglés

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AfterFormat!\n");
            Console.WriteLine("Would you like to install the application and tools in English (default) or Spanish?\n");
            Console.WriteLine("1. English (default)");
            Console.WriteLine("2. Spanish");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 2)
            {
                language = "es-ES";
            }

            while (true)
            {
                DisplayMainMenu();
                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                    HandleMainMenuSelection(option);
                else
                    Console.WriteLine("Invalid input. Please try again.");
            }
        }

        static void DisplayMainMenu()
        {
            Console.Clear();

            string[] menu = language == "en-US" ?
                new string[] {
                    "1. Browsers",
                    "2. Gaming",
                    "3. Drivers",
                    "4. Tools",
                    "5. Optimizations",
                    "6. Information"
                } :
                new string[] {
                    "1. Navegadores",
                    "2. Gaming",
                    "3. Controladores",
                    "4. Herramientas",
                    "5. Optimizaciones",
                    "6. Información"
                };

            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
        }

        static void HandleMainMenuSelection(int option)
        {
            switch (option)
            {
                case 1:
                    HandleBrowsersMenu();
                    break;
                case 2:
                    HandleGamingMenu();
                    break;
                case 3:
                    HandleDriversMenu();
                    break;
                case 4:
                    HandleToolsMenu();
                    break;
                case 5:
                    // Optimizaciones - Empty for now
                    break;
                case 6:
                    DisplayInformation();
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        static void HandleBrowsersMenu()
        {
            Console.Clear();

            string[] menu = language == "en-US" ?
                new string[] {
                    "1. Firefox",
                    "2. Firefox Nightly",
                    "3. Brave",
                    "4. Google Chrome",
                    "5. Ungoogled Chromium"
                } :
                new string[] {
                    "1. Firefox",
                    "2. Firefox Nightly (Versión nocturna)",
                    "3. Brave",
                    "4. Google Chrome",
                    "5. Chromium sin Google"
                };

            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        DownloadAndExecute($"Firefox Installer.{language}.exe");
                        break;
                    case 2:
                        DownloadAndExecute($"Firefox Nightly Installer.{language}.exe");
                        break;
                    case 3:
                        DownloadAndExecute("BraveBrowser.exe");
                        break;
                    case 4:
                        DownloadAndExecute("ChromeSetup.exe");
                        break;
                    case 5:
                        DownloadAndExecute("Ungoogled-Chromium.exe");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        static void HandleGamingMenu()
        {
            Console.Clear();

            string[] menu = {
                "1. Steam",
                "2. Epic Games Launcher",
                "3. Battle.Net"
            };

            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        DownloadAndExecute("SteamSetup.exe");
                        break;
                    case 2:
                        DownloadAndExecute("EpicInstaller.msi");
                        break;
                    case 3:
                        DownloadAndExecute("Battle.net-Setup.exe");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        static void HandleDriversMenu()
        {
            Console.Clear();

            string[] menu = {
                "1. Driver Booster",
                "2. Driver Easy"
            };

            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        DownloadAndUnzip("DriverBooster.zip", "DriverBoosterPortable.exe");
                        break;
                    case 2:
                        DownloadAndUnzip("DriverEasy.zip", "DriverEasyPortable.exe");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        static void HandleToolsMenu()
        {
            Console.Clear();

            string[] menu = {
                "1. 7Zip",
                "2. Winrar",
                "3. Ccleaner",
                "4. CPU-Z",
                "5. Core Temp"
            };

            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        DownloadAndExecute("7zip.exe");
                        break;
                    case 2:
                        DownloadAndExecute($"Winrar{language.Substring(3, 2)}.exe");
                        break;
                    case 3:
                        DownloadAndExecute("ccleaner.exe");
                        break;
                    case 4:
                        DownloadAndExecute("cpuz.exe");
                        break;
                    case 5:
                        DownloadAndExecute("Core-Temp-setup.exe");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        static void DownloadAndUnzip(string zipFileName, string executableName)
        {
            WebClient webClient = new WebClient();
            string downloadPath = Path.Combine(Path.GetTempPath(), zipFileName);
            webClient.DownloadFile(BaseGitHubLink + zipFileName, downloadPath);

            string unzipPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(zipFileName));
            System.IO.Compression.ZipFile.ExtractToDirectory(downloadPath, unzipPath);

            Process.Start(Path.Combine(unzipPath, executableName));
        }

        static void DisplayInformation()
        {
            Console.Clear();
            Console.WriteLine("AppName: AfterFormat");
            Console.WriteLine("Purpose: Tool to install essential software after a clean Windows install");
            Console.WriteLine("GitHub Link: https://github.com/redr00t/AfterFormat");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        static void DownloadAndExecute(string fileName)
        {
            WebClient webClient = new WebClient();
            string downloadPath = Path.Combine(Path.GetTempPath(), fileName);
            webClient.DownloadFile(BaseGitHubLink + fileName, downloadPath);
            Process.Start(downloadPath);
        }
    }
}
