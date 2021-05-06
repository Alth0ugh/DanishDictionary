using DanishDictionary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanishDictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestsPage : CarouselPage
    {
        public TestsPage()
        {
            InitializeComponent();
            BindingContext = new TestsViewModel(this);
        }
    }
}