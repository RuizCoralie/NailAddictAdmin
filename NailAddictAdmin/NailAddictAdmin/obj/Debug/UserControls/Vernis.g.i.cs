﻿#pragma checksum "..\..\..\UserControls\Vernis.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1DB7676FF9CEBECF12F3726D74C3A8ED"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using NailAddictAdmin.Converters;
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


namespace NailAddictAdmin.UserControls {
    
    
    /// <summary>
    /// Vernis
    /// </summary>
    public partial class Vernis : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\UserControls\Vernis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTitre;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\UserControls\Vernis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbAction;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\UserControls\Vernis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Valide;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\UserControls\Vernis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Supp;
        
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
            System.Uri resourceLocater = new System.Uri("/NailAddictAdmin;component/usercontrols/vernis.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\Vernis.xaml"
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
            this.tbTitre = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tbAction = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            
            #line 52 "..\..\..\UserControls\Vernis.xaml"
            ((System.Windows.Controls.DataGrid)(target)).PreviewMouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DataGrid_PreviewMouseRightButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Valide = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\UserControls\Vernis.xaml"
            this.btn_Valide.Click += new System.Windows.RoutedEventHandler(this.btn_Valide_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_Supp = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\UserControls\Vernis.xaml"
            this.btn_Supp.Click += new System.Windows.RoutedEventHandler(this.btn_Supp_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

