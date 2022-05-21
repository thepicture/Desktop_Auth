using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TelekomNevaSvyazWpfApp.Controls
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(BindablePasswordBox), new PropertyMetadata(null));



        public string BindablePassword
        {
            get { return (string)GetValue(BindablePasswordProperty); }
            set { SetValue(BindablePasswordProperty, value); }
        }

        public static readonly DependencyProperty BindablePasswordProperty =
            DependencyProperty.Register("BindablePassword",
                                        typeof(string),
                                        typeof(BindablePasswordBox),
                                        new FrameworkPropertyMetadata(default(string),
                                                                      FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                      OnBindablePasswordChanged));

        private static void OnBindablePasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                (d as BindablePasswordBox).PBoxPassword.Password = (string)e.NewValue;
            }
        }

        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            BindablePassword = (sender as PasswordBox).Password;
        }
    }
}
