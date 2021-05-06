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
        private bool _isErPlural;
        private bool _isRPlural;
        private bool _isDifferentPlural;
        private string _differentPluralText;
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
            var a = _isEnArticle || _isEtArticle;
            var b = _isErPlural || _isRPlural || _isDifferentPlural;
            return !String.IsNullOrWhiteSpace(_danishText)
                && !String.IsNullOrWhiteSpace(_slovakText) && (_isEnArticle || _isEtArticle) && ((_isErPlural || _isRPlural) || (_isDifferentPlural && !string.IsNullOrWhiteSpace(_differentPluralText)));
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
        public bool IsErPlural 
        {
            get => _isErPlural;
            set => SetProperty(ref _isErPlural, value);
        }
        public bool IsRPlural 
        {
            get => _isRPlural;
            set => SetProperty(ref _isRPlural, value);
        }
        public bool IsDifferentPlural 
        {
            get => _isDifferentPlural;
            set => SetProperty(ref _isDifferentPlural, value);
        }

        public string DifferentPluralText 
        {
            get => _differentPluralText;
            set => SetProperty(ref _differentPluralText, value);
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

            if (_isErPlural)
            {
                newItem.Plural = newItem.Danish + "er";
            }
            else if (_isRPlural)
            {
                newItem.Plural = newItem.Danish + "r";
            }
            else
            {
                newItem.Plural = _differentPluralText; 
            }

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
