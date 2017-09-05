
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LunchCode
{
    public class SimpleLunchPad : ContentPage
    {
        const int displayRow = 1;
        const int firstNumRow = 2;
        const int secondNumRow = 3;
        const int thirdNumRow = 4;
        const int fourthNumRow = 5;

        static Style plainButton = new Style(typeof(Button))
        {
            Setters = {
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#eee") },
                    new Setter { Property = Button.TextColorProperty, Value = Color.Black },
                    new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
                    new Setter { Property = Button.FontSizeProperty, Value = 40 }
                }
        };

        static Style darkerButton = new Style(typeof(Button))
        {
            Setters = {
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#ddd") },
                    new Setter { Property = Button.TextColorProperty, Value = Color.Black },
                    new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
                    new Setter { Property = Button.FontSizeProperty, Value = 40 }
                }
        };
        static Style orangeButton = new Style(typeof(Button))
        {
            Setters = {
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#E8AD00") },
                    new Setter { Property = Button.TextColorProperty, Value = Color.White },
                    new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
                    new Setter { Property = Button.FontSizeProperty, Value = 40 }
                }
        };

        static Style redButton = new Style(typeof(Button))
        {
            Setters = {
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#FF0000") },
                    new Setter { Property = Button.TextColorProperty, Value = Color.White },
                    new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
                    new Setter { Property = Button.FontSizeProperty, Value = 20 }
                }
        };

        static Style greenButton = new Style(typeof(Button))
        {
            Setters = {
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#006400") },
                    new Setter { Property = Button.TextColorProperty, Value = Color.White },
                    new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
                    new Setter { Property = Button.FontSizeProperty, Value = 20 }
                }
        };

        public List<Button> buttons = new List<Button>();
        private Button zeroButton;
        private Button oneButton;
        private Button twoButton;
        private Button threeButton;
        private Button fourButton;
        private Button fiveButton;
        private Button sixButton;
        private Button sevenButton;
        private Button eightButton;
        private Button nineButton;
        private Button clearButton;
        private Button enterButton;

        Label enteredValue;
        private Button trainingButton;
        bool trainingMode = false;

        public SimpleLunchPad()
        {
            Title = "LunchPad";
            BackgroundColor = Color.FromHex("#404040");
            BuildButtons();


            var controlGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            //controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


            trainingButton = new Button
            {
                Text = "Training Mode: Off",
                TextColor = Color.White,
                FontSize = 10,
                
            };
            controlGrid.Children.Add(trainingButton, 2, 0);
            trainingButton.Clicked += TrainingButton_Clicked;
            trainingButton.Clicked += Button_ClickedAnimate;


            enteredValue = new Label
            {
                Text = "0",
                HorizontalTextAlignment = TextAlignment.End,
                VerticalTextAlignment = TextAlignment.End,
                TextColor = Color.White,
                FontSize = 60
            };
            controlGrid.Children.Add(enteredValue, 0, displayRow);

            Grid.SetColumnSpan(enteredValue, 3);

            controlGrid.Children.Add(sevenButton, 0, firstNumRow);
            controlGrid.Children.Add(eightButton, 1, firstNumRow);
            controlGrid.Children.Add(nineButton, 2, firstNumRow);
            controlGrid.Children.Add(fourButton, 0, secondNumRow);
            controlGrid.Children.Add(fiveButton, 1, secondNumRow);
            controlGrid.Children.Add(sixButton, 2, secondNumRow);
            controlGrid.Children.Add(oneButton, 0, thirdNumRow);
            controlGrid.Children.Add(twoButton, 1, thirdNumRow);
            controlGrid.Children.Add(threeButton, 2, thirdNumRow);
            controlGrid.Children.Add(clearButton, 0, fourthNumRow);
            controlGrid.Children.Add(enterButton, 2, fourthNumRow);
            controlGrid.Children.Add(zeroButton, 1, fourthNumRow);
            //Grid.SetColumnSpan(zeroButton, 2);

            Content = controlGrid;
        }

        private void TrainingButton_Clicked(object sender, EventArgs e)
        {
            trainingMode = !trainingMode;
            if(trainingMode)
            {
                trainingButton.Text = "Training Mode: On";
            }
            else
            {
                trainingButton.Text = "Training Mode: Off";
            }
        }

        private void BuildButtons()
        {
            zeroButton = AddNumberButton("0", plainButton);
            oneButton = AddNumberButton("1", plainButton);
            twoButton = AddNumberButton("2", plainButton);
            threeButton = AddNumberButton("3", plainButton);
            fourButton = AddNumberButton("4", plainButton);
            fiveButton = AddNumberButton("5", plainButton);
            sixButton = AddNumberButton("6", plainButton);
            sevenButton = AddNumberButton("7", plainButton);
            eightButton = AddNumberButton("8", plainButton);
            nineButton = AddNumberButton("9", plainButton);

            clearButton = new Button { Text = "clear", Style = redButton };
            clearButton.Clicked += ClearButton_Clicked;
            clearButton.Clicked += Button_ClickedAnimate;
            enterButton = new Button { Text = "enter", Style = greenButton };
            enterButton.Clicked += EnterButton_Clicked;
            enterButton.Clicked += Button_ClickedAnimate;


        }

        private void EnterButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void ClearButton_Clicked(object sender, EventArgs e)
        {
            enteredValue.Text = "0";
        }

        private Button AddNumberButton(string text, Style style)
        {
            var button = new Button { Text = text, Style = style };
            button.Clicked += Button_Clicked;
            button.Clicked += Button_ClickedAnimate;
            buttons.Add(button);
            return button;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var buttonNumber = button.Text;
            AddNumber(buttonNumber);
        }

        private async void Button_ClickedAnimate(object sender, EventArgs e)
        {
            var button = (Button)sender;
            await button.ScaleTo(0.95, 50, Easing.CubicOut);
            await button.ScaleTo(1, 50, Easing.CubicIn);
        }

        private void AddNumber(string number)
        {
            if (enteredValue.Text.Length == 1 && enteredValue.Text[0] == '0')
            {
                enteredValue.Text = number;
            }
            else
            {
                enteredValue.Text = $"{enteredValue.Text}{number}";
            }
        }
    }
}
