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
    public partial class StartPage : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new Entry_Page(), new Timer_Page(), new BoxView_Page(), new Frame_Grig_Page(),new PopUp_Page(),new Failide_Page()}; // index= 0,1,2,...
        List<string> tekstid = new List<string> { "Ava entry leht", "Ava timer leht", "Ava box leht", "Ava frame leht", "Ava dialoogid","Ava failidega leht" };
        StackLayout st;
        public StartPage()
        {
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Yellow
            };

            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text= tekstid[i],
                    TabIndex= i,
                    BackgroundColor=Color.Violet,
                    TextColor= Color.White
                };
                st.Children.Add(button);
                button.Clicked += Navig_funktsion;
            }
            ScrollView sv = new ScrollView { Content = st };
            Content=sv;            
        }
        private async void Navig_funktsion(object sender, EventArgs e)
        {
            Button btn = sender as Button; //(Button)sender
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }       
    }
}