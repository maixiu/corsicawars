﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1ACCCC30E869031A66DEF9AD5960F53E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CorsicaWars;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CorsicaWars {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.MenuItem miNew;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.MenuItem miExit;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindow.xaml"
        internal System.Windows.Controls.MenuItem miAbout;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindow.xaml"
        internal CorsicaWars.PrettyGameBoard mainBoard;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CorsicaWars;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.miNew = ((System.Windows.Controls.MenuItem)(target));
            
            #line 9 "..\..\MainWindow.xaml"
            this.miNew.Click += new System.Windows.RoutedEventHandler(this.miNew_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.miExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 10 "..\..\MainWindow.xaml"
            this.miExit.Click += new System.Windows.RoutedEventHandler(this.miExit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.miAbout = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this.miAbout.Click += new System.Windows.RoutedEventHandler(this.miAbout_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.mainBoard = ((CorsicaWars.PrettyGameBoard)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
