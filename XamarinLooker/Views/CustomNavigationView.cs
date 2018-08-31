using System;

using Xamarin.Forms;

namespace XamarinLooker.Views
{
    public class CustomNavigationView : ContentPage
    {
        public CustomNavigationView()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

