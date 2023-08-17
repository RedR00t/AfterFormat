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
            DisplayBanner();
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

        static void DisplayBanner()
        {
            Console.WriteLine("\n");
            Console.WriteLine(" █████╗ ███████╗████████╗███████╗██████╗ ███████╗ ██████╗ ██████╗ ███╗   ███╗ █████╗ ████████╗");
            Console.WriteLine("██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗██╔════╝██╔═══██╗██╔══██╗████╗ ████║██╔══██╗╚══██╔══╝");
            Console.WriteLine("███████║█████╗     ██║   █████╗  ██████╔╝█████╗  ██║   ██║██████╔╝██╔████╔██║███████║   ██║   ");
            Console.WriteLine("██╔══██║██╔══╝     ██║   ██╔══╝  ██╔══██╗██╔══╝  ██║   ██║██╔══██╗██║╚██╔╝██║██╔══██║   ██║   ");
            Console.WriteLine("██║  ██║██║        ██║   ███████╗██║  ██║██║     ╚██████╔╝██║  ██║██║ ╚═╝ ██║██║  ██║   ██║   ");
            Console.WriteLine("╚═╝  ╚═╝╚═╝        ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ");
            Console.WriteLine("                           https://github.com/redr00t/AfterFormat                             ");
            Console.WriteLine("\n");
        }

        static void DisplayMainMenu()
        {
            Console.Clear();
            DisplayBanner();
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
            DisplayBanner();
            string[] menu = {
                    "1. Firefox",
                    "2. Firefox Nightly",
                    "3. Brave",
                    "4. Google Chrome",
                    "5. Ungoogled Chromium",
                    "\n0. Back to menu"
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
            DisplayBanner();
            string[] menu = {
                "1. Steam",
                "2. Epic Games Launcher",
                "3. Battle.Net",
                "\n0. Back to menu"
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
                        DownloadAndExecuteDirectly("https://epicgames-download1.akamaized.net/Builds/UnrealEngineLauncher/Installers/Win32/EpicInstaller-15.7.0.msi?launcherfilename=EpicInstaller-15.7.0.msi", "EpicInstaller-15.7.0.msi");
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
            DisplayBanner();
            string[] menu = {
                "1. Driver Booster",
                "2. Driver Easy",
                "\n0. Back to menu"
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
            DisplayBanner();
            string[] menu = {
                "1. Visual C++ AIO",
                "2. 7Zip",
                "3. WinRar",
                "4. Ccleaner",
                "5. CPU-Z",
                "6. Core Temp",
                "\n0. Back to menu"
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
                        DownloadAndExecuteDirectly("https://github.com/abbodi1406/vcredist/releases/download/v0.75.0/VisualCppRedist_AIO_x86_x64.exe", "VisualCppRedist_AIO_x86_x64.exe");
                        break;
                    case 2:
                        DownloadAndExecute("7zip.exe");
                        break;
                    case 3:
                        DownloadAndExecute($"Winrar{language.Substring(3, 2)}.exe");
                        break;
                    case 4:
                        DownloadAndExecute("ccleaner.exe");
                        break;
                    case 5:
                        DownloadAndExecute("cpuz.exe");
                        break;
                    case 6:
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

        static void DownloadAndExecuteDirectly(string fileUrl, string localFileName)
        {
            WebClient webClient = new WebClient();
            string downloadPath = Path.Combine(Path.GetTempPath(), localFileName);
            webClient.DownloadFile(fileUrl, downloadPath);
            Process.Start(downloadPath);
        }

    }
}
