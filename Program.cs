// Clipboard text replacer for automate clipboard text replace
// Onion site to normal site & Query string remover
// iNViTiON
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Text;

// https://stackoverflow.com/questions/621577/clipboard-event-c-sharp
// https://stackoverflow.com/questions/17762037/error-while-trying-to-copy-string-to-clipboard
// https://gist.github.com/glombard/7986317
// https://stackoverflow.com/questions/38148400/clipboard-monitor

internal static class NativeMethods
{
    // Reference https://docs.microsoft.com/en-us/windows/desktop/dataxchg/wm-clipboardupdate
    public const int WM_CLIPBOARDUPDATE = 0x031D;
    // Reference https://www.pinvoke.net/default.aspx/Constants.HWND
    public static IntPtr HWND_MESSAGE = new IntPtr(-3);

    // Reference https://www.pinvoke.net/default.aspx/user32/AddClipboardFormatListener.html
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool AddClipboardFormatListener(IntPtr hwnd);

    // Reference https://www.pinvoke.net/default.aspx/user32/RemoveClipboardFormatListener.html
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

    // Reference https://www.pinvoke.net/default.aspx/user32.setparent
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    // Reference https://www.pinvoke.net/default.aspx/user32/getwindowtext.html
    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    // Reference https://www.pinvoke.net/default.aspx/user32.getwindowtextlength
    [DllImport("user32.dll")]
    public static extern int GetWindowTextLength(IntPtr hWnd);

    // Reference https://www.pinvoke.net/default.aspx/user32.getforegroundwindow
    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();
}

public static class Clipboard
{
    public static string GetText()
    {
        string ReturnValue = string.Empty;
        Thread STAThread = new Thread(
            delegate ()
            {
                // Use a fully qualified name for Clipboard otherwise it
                // will end up calling itself.
                ReturnValue = System.Windows.Forms.Clipboard.GetText();
            });
        STAThread.SetApartmentState(ApartmentState.STA);
        STAThread.Start();
        STAThread.Join();

        return ReturnValue;
    }

    public static bool IsText()
    {
        bool ReturnValue = false;
        Thread STAThread = new Thread(
            delegate ()
            {
                ReturnValue = System.Windows.Forms.Clipboard.ContainsText();
            });
        STAThread.SetApartmentState(ApartmentState.STA);
        STAThread.Start();
        STAThread.Join();

        return ReturnValue;
    }
}

public sealed class ClipboardNotification
{
    private class NotificationForm : Form
    {
        // normal text replace
        (string from, string to)[] pairs = {
            ("bbcweb3hytmzhn5d532owbu6oqadra5z3ar726vq5kgwwn6aucdccrad.onion", "bbc.com"),
            ("duckduckgogg42xjoc72x3sjasowoarfbgcmvfimaftt6twagswzczad.onion", "duckduckgo.com"),
            ("facebookwkhpilnemxj7asaniu7vnjjbiltxjqhye3mhbshg7kx5tfyd.onion", "facebook.com"),
            ("twitter3e4tixl4xyajtrzo62zg5vztmjuricljdp2c5kshju4avyoid.onion", "twitter.com"),
        };
        // Regex text replace
        (string regex, string to)[] regexPairs = {
            /* 
             * Facebook
             *   fbclid
             *   __cft__[0]
             *   __tn__
             *   hoisted_section_header_type
             *   sfnsn
             *   notif_t
             *   notif_id
             *   notif_ref
             *   ref
             *   source
             *   extid
             * Twitter
             *   t
             *   s
             * Tiktok
             *   k
            */
            ("(?<=(\\?|&))(fbclid|__cft__\\[0\\]|__tn__|hoisted_section_header_type|sfnsn|notif_t|notif_id|notif_ref|ref|source|extid|t|s|k)(=.+?)(&|$)", ""),
            // remove "?" if empty query param
            ("(\\?|&)$", ""),
            // remove zero-width whitespace from SwiftKey
            ("(​)", ""),
        };

        public NotificationForm()
        {
            // Turn the child window into a message-only window (refer to Microsoft docs)
            NativeMethods.SetParent(Handle, NativeMethods.HWND_MESSAGE);
            // Place window in the system-maintained clipboard format listener list
            NativeMethods.AddClipboardFormatListener(Handle);
        }

        private void SetClipboard(string text)
        {
            // Deactivate listener to prevent infinite loop
            NativeMethods.RemoveClipboardFormatListener(Handle);
            System.Windows.Forms.Clipboard.SetText(text);
            NativeMethods.AddClipboardFormatListener(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages
            if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE && Clipboard.IsText())
            {
                string content = Clipboard.GetText();
                string replace = content;
                for (int i = 0; i < pairs.GetLength(0); ++i) replace = replace.Replace(pairs[i].from, pairs[i].to);
                for (int i = 0; i < regexPairs.GetLength(0); ++i) replace = Regex.Replace(replace, regexPairs[i].regex, regexPairs[i].to);
                if (content != replace) SetClipboard(replace);
            }
            // Called for any unhandled messages
            base.WndProc(ref m);
        }
    }

    [STAThread]
    private static void Main(string[] args)
    {
        // starts a message loop on current thread and displays specified form
        Application.Run(new NotificationForm());
    }
}