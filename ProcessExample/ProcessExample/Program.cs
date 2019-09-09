using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Налаштовуємо що саме запускать
            
            ProcessStartInfo startInfo = 
                new ProcessStartInfo(
                    @"notepad.exe", 
                    @"C:\Users\Vlad\Desktop\теми.txt"
                );
            
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;

            var process = new Process();
            process.StartInfo = startInfo;
            //Включити підтримку івентів
            process.EnableRaisingEvents = true;
            process.Exited += Process_Exited;

            //Запускає блокнот
            process.Start();

            //Вивести інфо про процес
            Console.WriteLine(process.Id);
            Console.WriteLine(process.ProcessName);
            Console.WriteLine(process.MainWindowTitle);
            
            
            Console.ReadKey();
        }

        private static void Process_Exited(object sender, EventArgs e)
        {
            Console.WriteLine("Notepad is closed!");
        }
    }
}
