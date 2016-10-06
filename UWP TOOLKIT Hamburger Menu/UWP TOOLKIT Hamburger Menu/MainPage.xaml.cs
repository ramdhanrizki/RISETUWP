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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_TOOLKIT_Hamburger_Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(View.Main));
            HamburgerMenuControl.ItemsSource = MenuItem.GetMainItems();
            HamburgerMenuControl.OptionsItemsSource = MenuItem.GetOptionsItems();
        }


        public class MenuItem
        {
            public Symbol Icon { get; set; }
            public String Name { get; set; }
            public Type PageType { get; set; }

            public static List<MenuItem> GetMainItems()
            {
                var items = new List<MenuItem>();
                items.Add(new MenuItem()
                {
                    Icon = Symbol.Home,
                    Name = "Home",
                    PageType = typeof(View.Main),
                });
                items.Add(new MenuItem()
                {
                    Icon = Symbol.AddFriend,
                    Name = "Add Friends",
                    PageType = typeof(View.Tambah),
                });
                return items;
            }

            public static List<MenuItem> GetOptionsItems()
            {
                var items = new List<MenuItem>();
                items.Add(new MenuItem() { Icon = Symbol.Setting, Name = "Settings", PageType = typeof(View.Setting) });
                return items;
            }
        }
        private void HamburgerMenuControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as MenuItem;
            mainFrame.Navigate(menuItem.PageType);
                
        }
        
    }
}
