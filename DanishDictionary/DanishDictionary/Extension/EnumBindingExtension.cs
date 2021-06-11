using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanishDictionary.Extension
{
    class EnumBindingExtension : IMarkupExtension
    {
        private bool _isConverterPresent;
        private Type _converter;
        public Type Value { get; set; }
        public Type Converter 
        {
            get => _converter;
            set
            {
                _converter = value;
                if (value == null)
                {
                    _isConverterPresent = false;
                    return;
                }

                _isConverterPresent = value is IValueConverter ? true : false;
            }
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Value == null)
            {
                return Binding.DoNothing;
            }
            object retVal;

            if (Value.IsEnum)
            {
                retVal = Value.GetEnumValues();
            }
            else
            {
                return Binding.DoNothing;
            }

            if (_isConverterPresent)
            {
                retVal = ((IValueConverter)Converter).Convert(retVal, null, null, null);
            }

            return retVal;
        }
    }
}
