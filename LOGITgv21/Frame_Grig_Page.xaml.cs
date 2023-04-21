using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LOGITgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Frame_Grig_Page : ContentPage
    {
        Frame fr;
        Label lbl;
        Grid gr;
        int r, g, b;
        Random rnd;
        public Frame_Grig_Page()
        {
            rnd= new Random();
            lbl = new Label
            {
                Text = "Raami kujundus",
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label))
            };
            gr = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            List<int> laiused = new List<int> { 2,1,1};// { (int)DeviceDisplay.MainDisplayInfo.Height/20, (int)(DeviceDisplay.MainDisplayInfo.Height)/40, (int)DeviceDisplay.MainDisplayInfo.Height/20 };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    r = rnd.Next(0, 255);
                    g = rnd.Next(0, 255);
                    b = rnd.Next(0, 255);
                    gr.RowDefinitions.Add(new RowDefinition { Height = new GridLength(laiused[i], GridUnitType.Star) });
                    gr.Children.Add(
                        new BoxView 
                        { 
                        Color = Color.FromRgb(r,g,b),
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                        }, j, i);
                }
                gr.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            fr = new Frame
            {
                Content = gr,
                BorderColor = Color.FromRgb(20, 120, 255),
                CornerRadius = 30,
                
            };
            StackLayout st = new StackLayout
            {
                Children = { lbl, fr }
            };
            Content = st;
        }
    }
}