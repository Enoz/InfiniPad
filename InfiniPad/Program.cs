using System;
using System.Windows.Forms;
using System.Threading;

namespace InfiniPad
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Mutex
            bool boolptr;
            Mutex m = new Mutex(true, "InfiniPadMutex", out boolptr);
            if (!boolptr)
                return;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
