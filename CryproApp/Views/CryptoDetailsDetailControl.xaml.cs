using System;

using CryproApp.Core.Models;
using CryproApp.Core.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CryproApp.Views
{
    public sealed partial class CryptoDetailsDetailControl : UserControl
    {
        public Currency ListMenuItem
        {
            get { return GetValue(ListMenuItemProperty) as Currency; }
            set { SetValue(ListMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListMenuItemProperty = DependencyProperty.Register("ListMenuItem", typeof(Currency), typeof(CryptoDetailsDetailControl), new PropertyMetadata(null, OnListMenuItemPropertyChanged));

        public CryptoDetailsDetailControl()
        {
            InitializeComponent();           
        }

        private static void OnListMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CryptoDetailsDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
