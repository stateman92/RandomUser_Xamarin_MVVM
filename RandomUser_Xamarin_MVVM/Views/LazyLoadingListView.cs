using System;
using System.Collections;
using System.Windows.Input;

using Xamarin.Forms;

namespace RandomUser_Xamarin_MVVM.Views
{
    public class LazyLoadingListView : ListView
    {
        [Obsolete]
        public static readonly BindableProperty LoadMoreCommandProperty
            = BindableProperty.Create<LazyLoadingListView, ICommand>(bp => bp.LoadMoreCommand, default);

        [Obsolete]
        public ICommand LoadMoreCommand
        {
            get { return (ICommand)GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        public LazyLoadingListView()
        {
            RegisterLayzyLoading();
        }

        public LazyLoadingListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
            RegisterLayzyLoading();
        }

        void RegisterLayzyLoading()
        {
            ItemAppearing += InfiniteListView_ItemAppearing;
        }

        object lastItem;

        [Obsolete]
        void InfiniteListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            // If last item is in view: load more items.
            if (ItemsSource is IList items && e.Item == items[items.Count - 1])
            {
                if (e.Item != lastItem && LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                {
                    lastItem = e.Item;
                    LoadMoreCommand.Execute(null);
                }
            }
        }
    }
}
