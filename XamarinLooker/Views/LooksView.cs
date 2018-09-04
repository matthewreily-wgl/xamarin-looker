using System;

using Xamarin.Forms;

namespace XamarinLooker.Views
{
    public class LooksView : ContentPage
    {
        public LooksView()
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

