﻿#pragma checksum "c:\users\ramdhan\documents\visual studio 2015\Riset\UWP TOOLKIT Hamburger Menu\UWP TOOLKIT Hamburger Menu\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BD30E1E30702EF7B593C5098DD0062CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UWP_TOOLKIT_Hamburger_Menu
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.HamburgerTemplate = (global::Windows.UI.Xaml.DataTemplate)(target);
                }
                break;
            case 2:
                {
                    this.HamburgerMenuControl = (global::Microsoft.Toolkit.Uwp.UI.Controls.HamburgerMenu)(target);
                    #line 24 "..\..\..\MainPage.xaml"
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.HamburgerMenu)this.HamburgerMenuControl).ItemClick += this.HamburgerMenuControl_ItemClick;
                    #line 27 "..\..\..\MainPage.xaml"
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.HamburgerMenu)this.HamburgerMenuControl).OptionsItemClick += this.HamburgerMenuControl_ItemClick;
                    #line default
                }
                break;
            case 3:
                {
                    this.mainFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

