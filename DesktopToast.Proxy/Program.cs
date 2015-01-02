﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesktopToast.Proxy
{
    class Program
    {
        static string resultString = null;

        static void Main(string[] args)
        {
            var requestString = args.Any() ? args[0] : null;
            if (requestString == null)
            {
#if DEBUG
                requestString = @"{
""AppId"":""DesktopToast.Proxy"",
""ShortcutFileName"":""DesktopToast.Proxy.lnk"",
""ShortcutTargetFilePath"":""C:\\DesktopToast.Proxy.exe"",
""ToastBody"":""This is a toast test."",
""ToastHeadline"":""DesktopToast Proxy Sample"",
}";
#endif
#if !DEBUG
                return;
#endif
            }

            var showToastTask = ShowToastAsync(requestString);

            while (resultString == null)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }

            Console.WriteLine(resultString);
        }

        static async Task ShowToastAsync(string requestString)
        {
            var result = await ToastManager.ShowAsync(requestString);

            resultString = result.ToString();
        }
    }
}