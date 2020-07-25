using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace tbrn_macabeos_app
{
    public class SplashPage : ContentPage
    {
        Image splashImage;
        public int servidor;
        public int acceso;
        public int usuario;

        public SplashPage(int parameter1, int parameter2, int parameter3)
        {
            servidor = parameter1;
            acceso = parameter2;
            usuario = parameter3;
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "splahLogo.png",
                WidthRequest = 300,
                HeightRequest = 300
            };

            AbsoluteLayout.SetLayoutFlags(splashImage,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#E6E7EA");
            this.Content = sub;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await splashImage.ScaleTo(150, 1200, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new Principal(servidor, acceso, usuario));    //After loading  MainPage it gets Navigated to our new Page
        }
    }
    
}
