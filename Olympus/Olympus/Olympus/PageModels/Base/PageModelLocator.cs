using System;
using System.Collections.Generic;
using TinyIoC;
using Xamarin.Forms;

namespace Olympus.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer mContainer;
        static Dictionary<Type, Type> mViewLookup;

        static PageModelLocator()
        {
            mContainer = new TinyIoCContainer();
            mViewLookup = new Dictionary<Type, Type>();
        }

        public static T Resolve<T>() where T : class
        {
            return mContainer.Resolve<T>();
        }

        public  static Page CreatePageFor(Type pPageModelType)
        {
            var pageType = mViewLookup[pPageModelType];
            Page page = (Page)Activator.CreateInstance(pageType);
            var pageModel = mContainer.Resolve(pageType);

            page.BindingContext = pageModel;
            return page;
        }
    }

}
