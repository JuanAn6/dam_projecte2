﻿#pragma checksum "..\..\..\..\Views\ProductsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4E59A948F76389B4728BDE54A94BC5D64818AF13"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjecteBotigaSabates.Components;
using ProjecteBotigaSabates.Views;
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


namespace ProjecteBotigaSabates.Views {
    
    
    /// <summary>
    /// ProductsPage
    /// </summary>
    public partial class ProductsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Views\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BreadCrumbs;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Views\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_search;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Views\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock sl_price_val;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Views\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sl_price;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Views\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView trv_categories;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Views\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lv_products;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Views\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_page;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\Views\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_max_page;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjecteBotigaSabates;component/views/productspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ProductsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\Views\ProductsPage.xaml"
            ((ProjecteBotigaSabates.Views.ProductsPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BreadCrumbs = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.tb_search = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\..\Views\ProductsPage.xaml"
            this.tb_search.KeyUp += new System.Windows.Input.KeyEventHandler(this.Button_Search_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 29 "..\..\..\..\Views\ProductsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Search_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.sl_price_val = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 46 "..\..\..\..\Views\ProductsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Slide_Filter_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.sl_price = ((System.Windows.Controls.Slider)(target));
            
            #line 53 "..\..\..\..\Views\ProductsPage.xaml"
            this.sl_price.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sl_price_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.trv_categories = ((System.Windows.Controls.TreeView)(target));
            return;
            case 9:
            this.lv_products = ((System.Windows.Controls.ListView)(target));
            
            #line 62 "..\..\..\..\Views\ProductsPage.xaml"
            this.lv_products.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lv_products_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 108 "..\..\..\..\Views\ProductsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Previous_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.tb_page = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.tb_max_page = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            
            #line 111 "..\..\..\..\Views\ProductsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Next_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

