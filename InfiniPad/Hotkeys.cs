using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace InfiniPad
{
    public static class KeyModifiers
    {
        public const int MOD_ALT = 0x0001;
        public const int MOD_CONTROL = 0x0002;
        public const int MOD_NOREPEAT = 0x4000;
        public const int MOD_SHIFT = 0x0004;
        public const int MOD_WIN = 0x0008;

        public const int WM_HOTKEY_MSG_ID = 0x0312;
    }

    
    

    public sealed class Hotkeys : NativeWindow, IDisposable
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int curID = 100;

        private struct Registrar
        {
            public Action func;
            public string indentifier;
            public int Modifiers;
            public int vk;
            public int hkID;
            public Registrar(Action f, string id, int mod, int key, int ID)
            {
                this.func = f;
                this.indentifier = id;
                this.Modifiers = mod;
                this.vk = key;
                this.hkID = ID;
            }
        }

        private List<Registrar> hooks = new List<Registrar>();

        public Hotkeys()
        {
            CreateHandle(new CreateParams());
        }

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == KeyModifiers.WM_HOTKEY_MSG_ID)
            {
                try
                {
                    foreach (Registrar rr in hooks)
                    {
                        if (m.WParam.ToInt32() == rr.hkID && Properties.Settings.Default.HotkeysEnabled)
                        {
                            rr.func();
                        }
                    }
                }
                catch (Exception) { }
            }
            base.WndProc(ref m);
        }

        public void Register(Action runFunc, string identifier, int fsModifiers, int vk)
        {
            DeleteHotkey(identifier);
            var rr = new Registrar(runFunc, identifier, fsModifiers, vk, curID);
            curID++;
            RegisterHotKey(this.Handle, rr.hkID, rr.Modifiers, rr.vk);
            hooks.Add(rr);
        }

        public void DeleteHotkey(string identifier)
        {
            foreach(Registrar rr in hooks.ToArray())
            {
                if(rr.indentifier == identifier)
                {
                    UnregisterHotKey(this.Handle, rr.hkID);
                    hooks.Remove(rr);
                    return;
                }
            }
        }

        public void ReapplyHotkeys()
        {
            Register(Main.TakePartialScreen, "PartialScreen", KeyModifiers.MOD_NOREPEAT | Properties.Settings.Default.PartialModifiers, Properties.Settings.Default.PartialHotkey);
            Register(Main.TakeFullScreen, "FullScreen", KeyModifiers.MOD_NOREPEAT | Properties.Settings.Default.MonitorModifiers, Properties.Settings.Default.MonitorHotkey);
        }


        public void Dispose()
        {
            while (hooks.Count > 0)
                DeleteHotkey(hooks.First().indentifier);
            DestroyHandle();
        }



    }
}
