﻿#pragma checksum "..\..\..\DataFullScreen\CarsFullScreen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C01BD22843740FEA6D3AA0A0DD198217C8CCEDA3E92BD1A5A30FDD13E3EFC8A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarShop228.DataFullScreen;
using System;
using System.Diagnostics;
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
using System.Windows.Shell;


namespace CarShop228.DataFullScreen {
    
    
    /// <summary>
    /// CarsFullScreen
    /// </summary>
    public partial class CarsFullScreen : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 18 "..\..\..\DataFullScreen\CarsFullScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Export;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\DataFullScreen\CarsFullScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Catalog_DataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarShop228;component/datafullscreen/carsfullscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DataFullScreen\CarsFullScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\DataFullScreen\CarsFullScreen.xaml"
            ((CarShop228.DataFullScreen.CarsFullScreen)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\..\DataFullScreen\CarsFullScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Btn_CLick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Export = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\DataFullScreen\CarsFullScreen.xaml"
            this.Export.Click += new System.Windows.RoutedEventHandler(this.Export_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 19 "..\..\..\DataFullScreen\CarsFullScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Del_Btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 20 "..\..\..\DataFullScreen\CarsFullScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Refresh_Btn);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 21 "..\..\..\DataFullScreen\CarsFullScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Catalog_DataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 8:
            
            #line 35 "..\..\..\DataFullScreen\CarsFullScreen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_Btn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
