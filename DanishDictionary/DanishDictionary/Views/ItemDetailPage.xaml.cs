using DanishDictionary.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DanishDictionary.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}