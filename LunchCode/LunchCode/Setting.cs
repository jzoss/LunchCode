using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LunchCode
{
	public class Setting : ContentPage
	{
        Entry nameEditor = new Entry();
        Entry pinEditor = new Entry();


        public Setting ()
		{
            var layout = new StackLayout { Padding = new Thickness(5, 10) };
            this.Title = "Settings";
            layout.Children.Add(new Label { Text = "This page demonstrates the Editor View. The Editor is used for collecting text that is expected to take more than one line." });
            nameEditor = new Entry { Placeholder = "Child's Name" };
            pinEditor = new Entry { Placeholder = "Lunch PIN", Keyboard = Keyboard.Numeric };

            if(SettingManager.IsNameSet)
            {
                nameEditor.Text = SettingManager.Name;
            }

            if (SettingManager.IsPinSet)
            {
                pinEditor.Text = SettingManager.Pin.ToString();
            }

            nameEditor.Completed += NameEditor_Completed;
            pinEditor.Completed += PinEditor_Completed;

            layout.Children.Add(nameEditor);
            layout.Children.Add(pinEditor);
            this.Content = layout;
        }

        private void PinEditor_Completed(object sender, EventArgs e)
        {
            int pin = 0;
            if(int.TryParse(pinEditor.Text, out pin))
            {
                SettingManager.Pin = pin;
            }
            
        }

        private void NameEditor_Completed(object sender, EventArgs e)
        {
            SettingManager.Name = nameEditor.Text;
        }

    }
}