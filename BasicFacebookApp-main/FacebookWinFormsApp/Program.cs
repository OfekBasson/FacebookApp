using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // TODO: Change this back
            //Clipboard.SetText("design.patterns20cc");
            Clipboard.SetText("ofekofekfacebook@gmail.com");
            FacebookService.s_UseForamttedToStrings = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Initialize CEF on the UI thread
            Cef.Initialize(new CefSettings());

            FormMain mainForm = new FormMain();

            // Attach shutdown logic to the FormClosed event
            mainForm.FormClosed += (sender, args) =>
            {
                Cef.Shutdown();
            };
            Application.Run(mainForm);
        }
    }
}