using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Plugin.Logger;
using Plugin.Logger.Abstractions;

namespace UsingLoggerPlugin.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            CrossLogger.Current.Configure("UsingLoggerPlugin.log", 3, 100, LogLevel.Debug, true);
            CrossLogger.Current.Log(LogLevel.Info, "UsingLoggerPlugin", "Log Started");
            string log = CrossLogger.Current.GetAll();

            LoadApplication(new UsingLoggerPlugin.App());
        }
    }
}
