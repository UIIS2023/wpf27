﻿#pragma checksum "..\..\..\..\Forme\FrmPutovanje.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5B32E9D3772EE20D3522ADE5BEE7A60CCB03A22F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using TuristickaAgencijaWPF.Forme;


namespace TuristickaAgencijaWPF.Forme {
    
    
    /// <summary>
    /// FrmPutovanje
    /// </summary>
    public partial class FrmPutovanje : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\Forme\FrmPutovanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBrojDana;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Forme\FrmPutovanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCijena;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Forme\FrmPutovanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDatum;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Forme\FrmPutovanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbVrsta;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Forme\FrmPutovanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbDestinacija;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Forme\FrmPutovanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbKlijent;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Forme\FrmPutovanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Forme\FrmPutovanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TuristickaAgencijaWPF;component/forme/frmputovanje.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forme\FrmPutovanje.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtBrojDana = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtCijena = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dpDatum = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.cbVrsta = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbDestinacija = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.cbKlijent = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Forme\FrmPutovanje.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\Forme\FrmPutovanje.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

