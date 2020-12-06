using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Olympus.PageModels.Base
{
    public class PageModelBase : BindableObject
    {
        public String  Title
        {
            get => mTitle;
            set => setProperty(ref mTitle, value);
        }

        string mTitle;

        protected bool setProperty<T>(ref T pStorage, T pValue, [CallerMemberName]string pPropertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(pStorage, pValue))
            {
                return false;
            }
            else
            {
                pStorage = pValue;
                OnPropertyChanged(pPropertyName);
                return true;
            }
        }
    }
}