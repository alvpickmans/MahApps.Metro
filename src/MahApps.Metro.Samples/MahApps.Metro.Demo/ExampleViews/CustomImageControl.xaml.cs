using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MetroDemo.ExampleViews
{
    /// <summary>
    /// Interaction logic for CustomImageControl.xaml
    /// </summary>
    public partial class CustomImageControl : UserControl
    {
        public ImageSource SourceImage
        {
            get => (ImageSource)this.GetValue(SourceImageProperty);
            set
            {
                this.SetValue(SourceImageProperty, value);
            }
        }

        public static readonly DependencyProperty SourceImageProperty = DependencyProperty.Register(
          nameof(SourceImage),
          typeof(ImageSource),
          typeof(CustomImageControl),
          new PropertyMetadata(OnSourceImageChanged));

        private static void OnSourceImageChanged(DependencyObject data, DependencyPropertyChangedEventArgs args)
        {
            var control = (CustomImageControl)data;
            if (control is null || !(args.NewValue is ImageSource image))
                return;

            control.SourceImage = image;
        }

        public CustomImageControl()
        {
            InitializeComponent();
            this.ControlContainer.DataContext = this;
        }
    }
}