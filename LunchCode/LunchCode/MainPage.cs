using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LunchCode
{
    public class MainPage : MasterDetailPage
    {
        MasterPage masterPage;

        public MainPage()
        {
            masterPage = new MasterPage();
            Master = masterPage;
            Detail = new NavigationPage(new SimpleLunchPad());

            masterPage.ListView.ItemSelected += OnItemSelected;

            //if (Device.RuntimePlatform == Device.Windows)
            //{
            //    MasterBehavior = MasterBehavior.Popover;
            //}
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
