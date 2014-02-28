﻿// FFXIVAPP.Updater
// App.cs
// 
// © 2013 Ryan Wilson

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using NLog;

namespace FFXIVAPP.Updater
{
    public partial class App
    {
        #region Logger

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Property Bindings

        #endregion

        private App()
        {
            Startup += ApplicationStartup;
            StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
            var resourceLocater = new Uri("/FFXIVAPP.Updater;component/App.xaml", UriKind.Relative);
            LoadComponent(this, resourceLocater);
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
            Dispatcher.UnhandledExceptionFilter += DispatcherOnUnhandledExceptionFilter;
        }

        /// <summary>
        ///     Application Entry Point.
        /// </summary>
        [STAThread]
        [DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        [LoaderOptimization(LoaderOptimization.MultiDomainHost)]
        public static void Main()
        {
            var app = new App();
            app.Run();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="startupEventArgs"> </param>
        private void ApplicationStartup(object sender, StartupEventArgs startupEventArgs)
        {
            if (startupEventArgs.Args.Length <= 0)
            {
                return;
            }
            Properties["DownloadUri"] = startupEventArgs.Args[0];
            Properties["Version"] = startupEventArgs.Args[1];
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private static void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.Message);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispatcherOnUnhandledExceptionFilter(object sender, DispatcherUnhandledExceptionFilterEventArgs e)
        {
            e.RequestCatch = true;
            MessageBox.Show(e.Exception.Message);
        }
    }
}