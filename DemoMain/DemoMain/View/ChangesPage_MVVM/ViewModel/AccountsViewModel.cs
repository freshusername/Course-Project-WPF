using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DemoMain.View.ChangesPage_MVVM.ViewModel
{
    public class AccountsViewModel : DependencyObject
    {

        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(AccountsViewModel), new PropertyMetadata(""));



        public ICollectionView Accs
        {
            get { return (ICollectionView)GetValue(AccsProperty); }
            set { SetValue(AccsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(AccountsViewModel), new PropertyMetadata(null));



        public AccountsViewModel()
        {
            Accs = CollectionViewSource.GetDefaultView(Accounts.GetAccounts());
        }

    }
}
