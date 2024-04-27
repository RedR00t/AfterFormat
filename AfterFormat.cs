using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace AfterFormat
{
    internal class Program
    {
        private static readonly string BaseGitHubLink = "https://raw.githubusercontent.com/redr00t/AfterFormat/main/Files/";
        private static string language = "en-US"; // Por defecto en inglés

        private static void Main(string[] args)
        {
            DisplayBanner();
            Console.WriteLine("Welcome to AfterFormat!\n");
            Console.WriteLine("Would you like to run the application and tools in English (default) or Spanish?\n");
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
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    HandleMainMenuSelection(option);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        private static void DisplayBanner()
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

        private static void DisplayMainMenu()
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

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }

        private static void HandleMainMenuSelection(int option)
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
                    HandleOptimizationsMenu();
                    break;
                case 6:
                    DisplayInformation();
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private static void HandleBrowsersMenu()
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

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }

            if (int.TryParse(Console.ReadLine(), out int choice))
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
                        DownloadAndExecuteDirectly("https://referrals.brave.com/latest/BraveBrowserSetup-BRV030.exe", "BraveBrowserSetup-BRV030.exe");
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

        private static void HandleGamingMenu()
        {
            Console.Clear();
            DisplayBanner();
            string[] menu = {
                "1. Steam",
                "2. Epic Games Launcher",
                "3. Battle.Net",
                "\n0. Back to menu"
            };

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }

            if (int.TryParse(Console.ReadLine(), out int choice))
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

        private static void HandleDriversMenu()
        {
            Console.Clear();
            DisplayBanner();
            string[] menu = {
                "1. Driver Booster",
                "2. Driver Easy",
                "\n0. Back to menu"
            };

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }

            if (int.TryParse(Console.ReadLine(), out int choice))
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

        private static void HandleToolsMenu()
        {
            Console.Clear();
            DisplayBanner();
            string[] menu = {
                "1. Visual C++ AIO",
                "2. 7Zip",
                "3. WinRar",
                "4. DirectX 2010 Redis",
                "5. Ccleaner",
                "6. CPU-Z",
                "7. Core Temp",
                "\n0. Back to menu"
            };

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }

            if (int.TryParse(Console.ReadLine(), out int choice))
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
                        DownloadAndExecute("directx_Jun2010_redist.exe");
                        break;
                    case 5:
                        DownloadAndExecute("ccleaner.exe");
                        break;
                    case 6:
                        DownloadAndExecute("cpuz.exe");
                        break;
                    case 7:
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

        private static void HandleOptimizationsMenu()
        {
            Console.Clear();
            DisplayBanner();

            string[] menu = language == "en-US" ?
            new string[] {
                "1. Apply all recommended optimizations",
                "2. Disable Background Blur on Lock Screen",
                "3. Disable Startup Delay",
                "4. Enable Ultimate Performance Power Mode",
                "5. Disable C States C2 and C3",
                "6. Disable MS-GamingOverlay",
                "7. Disable Multi-Plane Overlay (MPO)",
                "8. Disable Bing Search in the Start Menu",
                "9. Restore legacy Alt + Tab",
                "\n0. Back to menu"
            } :
            new string[] {
                "1. Aplicar todas las optimizaciones recomendadas",
                "2. Deshabilitar Background Blur en Pantalla de bloqueo",
                "3. Deshabilitar Startup Delay",
                "4. Habilitar modo energético Ultimate Performance",
                "5. Deshabilitar C States C2 y C3",
                "6. Deshabilitar MS-GamingOverlay",
                "7. Deshabilitar Multi-Plane Overlay (MPO)",
                "8. Deshabilitar Busqueda de Bing en menú de inicio",
                "9. Restaurar Alt + Tab de legado",
                "\n0. Regresar al menú"
            };

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        SetRegistryKey(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_Enabled", 0);
                        SetRegistryKey(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR", "AppCaptureEnabled", 0);
                        SetRegistryKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "AltTabSettings", 1);
                        break;
                    case 2:
                        SetRegistryKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "DisableAcrylicBackgroundOnLogon", 1);
                        break;
                    case 3:
                        SetRegistryKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Serialize", "StartupDelayInMSec", 0);
                        break;
                    case 4:
                        string currentDirectory = Directory.GetCurrentDirectory();
                        ExecutePowerShellCommand($"powercfg -import \"{currentDirectory}\\Ultimate.pow\"");
                        break;
                    case 5:
                        SetRegistryKey(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Processor", "Capabilities", 0x0007e066);
                        break;
                    case 6:
                        SetRegistryKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\Dwm", "OverlayTestMode", 5);
                        break;
                    case 7:
                        SetRegistryKey(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer", "DisableSearchBoxSuggestions", 1);
                        break;
                    case 8:
                        SetRegistryKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "AltTabSettings", 1);
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

        private static void SetRegistryKey(string path, string name, object value)
        {
            try
            {
                var parts = path.Split(new string[] { "\\" }, 2, StringSplitOptions.None);
                if (parts.Length < 2)
                {
                    throw new Exception($"Invalid registry path format: {path}");
                }

                var hivePart = parts[0];
                var subPath = parts[1];

                Microsoft.Win32.RegistryKey baseKey;

                switch (hivePart)
                {
                    case "HKEY_CLASSES_ROOT":
                        baseKey = Microsoft.Win32.Registry.ClassesRoot;
                        break;
                    case "HKEY_CURRENT_USER":
                        baseKey = Microsoft.Win32.Registry.CurrentUser;
                        break;
                    case "HKEY_LOCAL_MACHINE":
                        baseKey = Microsoft.Win32.Registry.LocalMachine;
                        break;
                    case "HKEY_USERS":
                        baseKey = Microsoft.Win32.Registry.Users;
                        break;
                    case "HKEY_CURRENT_CONFIG":
                        baseKey = Microsoft.Win32.Registry.CurrentConfig;
                        break;
                    default:
                        throw new Exception($"Unsupported hive: {hivePart}");
                }
                using (var key = baseKey.CreateSubKey(subPath, true))
                {
                    if (key == null)
                    {
                        throw new Exception($"Failed to open or create registry key at {path}");
                    }
                    key.SetValue(name, value);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Failed to set registry key: {path}\\{name}. Error: {ex.Message}";
                Console.WriteLine(errorMessage);
                AppendToLog(errorMessage);
            }
        }

        private static void AppendToLog(string message)
        {
            string logFilePath = "log.txt";
            try
            {
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file. Error: {ex.Message}");
            }
        }

        private static void ExecutePowerShellCommand(string command)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command {command}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(result);
        }


        private static void DownloadAndUnzip(string zipFileName, string executableName)
        {
            WebClient webClient = new WebClient();
            string downloadPath = Path.Combine(Path.GetTempPath(), zipFileName);
            webClient.DownloadFile(BaseGitHubLink + zipFileName, downloadPath);

            string unzipPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(zipFileName));
            if (Directory.Exists(unzipPath))
            {
                Directory.Delete(unzipPath, true);
            }
            System.IO.Compression.ZipFile.ExtractToDirectory(downloadPath, unzipPath);

            Process.Start(Path.Combine(unzipPath, executableName));
        }

        private static void DisplayInformation()
        {
            Console.Clear();
            Console.WriteLine("AppName: AfterFormat");
            Console.WriteLine("Purpose: Tool to install essential software after a clean Windows install");
            Console.WriteLine("GitHub Link: https://github.com/redr00t/AfterFormat");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        private static void DownloadAndExecute(string fileName)
        {
            WebClient webClient = new WebClient();
            string downloadPath = Path.Combine(Path.GetTempPath(), fileName);
            webClient.DownloadFile(BaseGitHubLink + fileName, downloadPath);
            Process.Start(downloadPath);
        }

        private static void DownloadAndExecuteDirectly(string fileUrl, string localFileName)
        {
            WebClient webClient = new WebClient();
            string downloadPath = Path.Combine(Path.GetTempPath(), localFileName);
            webClient.DownloadFile(fileUrl, downloadPath);
            Process.Start(downloadPath);
        }
    }
}
