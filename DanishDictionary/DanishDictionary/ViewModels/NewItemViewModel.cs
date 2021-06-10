using DanishDictionary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DanishDictionary.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string _danishText;
        private string _slovakText;
        private bool _isEnArticle;
        private bool _isEtArticle;
        private string _pluralText;
        private bool _canSave;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) =>
            {
                if (ValidateSave() != _canSave)
                {
                    SaveCommand.ChangeCanExecute();
                    _canSave = !_canSave;
                }
            };
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_danishText)
                && !String.IsNullOrWhiteSpace(_slovakText) && (_isEnArticle || _isEtArticle) && !string.IsNullOrWhiteSpace(_pluralText);
        }

        public string DanishText
        {
            get => _danishText;
            set => SetProperty(ref _danishText, value);
        }

        public string SlovakText
        {
            get => _slovakText;
            set => SetProperty(ref _slovakText, value);
        }

        public bool IsEnArticle 
        {
            get => _isEnArticle;
            set => SetProperty(ref _isEnArticle, value);
        }
        public bool IsEtArticle 
        {
            get => _isEtArticle;
            set => SetProperty(ref _isEtArticle, value);
        }

        public string PluralText 
        {
            get => _pluralText;
            set => SetProperty(ref _pluralText, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Word newItem = new Word()
            {
                Danish = DanishText,
                Slovak = SlovakText,
                Article = _isEnArticle ? Articles.En : Articles.Et
            };

            newItem.Plural = _pluralText;

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
