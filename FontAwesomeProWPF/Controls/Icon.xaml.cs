using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FontAwesomePro.WPF.Controls
{
    /// <summary>
    /// Interaktionslogik für Icon.xaml
    /// </summary>
    public partial class Icon : UserControl
    {
        private static FontFamily _Brands = new FontFamily(new Uri("pack://application:,,,/FontAwesomeProWPF;component/"), "./FontAwesome/otfs/#Font Awesome 5 Brands Regular");
        private static FontFamily _Solid = new FontFamily(new Uri("pack://application:,,,/FontAwesomeProWPF;component/"), "./FontAwesome/otfs/#Font Awesome 5 Pro Solid");
        private static FontFamily _Regular = new FontFamily(new Uri("pack://application:,,,/FontAwesomeProWPF;component/"), "./FontAwesome/otfs/#Font Awesome 5 Pro Regular");
        private static FontFamily _Light = new FontFamily(new Uri("pack://application:,,,/FontAwesomeProWPF;component/"), "./FontAwesome/otfs/#Font Awesome 5 Pro Light");
        private static FontFamily _Duotone = new FontFamily(new Uri("pack://application:,,,/FontAwesomeProWPF;component/"), "./FontAwesome/otfs/#Font Awesome 5 Duotone Solid");

        public FaStyles FaStyle
        {
            get { return (FaStyles)GetValue(FaStyleProperty); }
            set { SetValue(FaStyleProperty, value); }
        }
        public static readonly DependencyProperty FaStyleProperty =
            DependencyProperty.Register("FaStyle", typeof(FaStyles), typeof(Icon),
            new FrameworkPropertyMetadata(FaStyles.None, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnUpdateControl)));

        public string FaName
        {
            get { return (string)GetValue(FaNameProperty); }
            set { SetValue(FaNameProperty, value); }
        }
        public static readonly DependencyProperty FaNameProperty =
            DependencyProperty.Register("FaName", typeof(string), typeof(Icon),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnUpdateControl)));

        public Icon()
        {
            InitializeComponent();
            _placeholder.FontFamily = _Regular;
            _placeholder.Text = null;
        }

        private static void OnUpdateControl(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = d as Icon;
            if (ctrl == null)
                return;

            ctrl._placeholder.Text = null;
            ctrl._placeholder.FontFamily = _Regular;

            if (string.IsNullOrWhiteSpace(ctrl.FaName))
                return;

            var style = ctrl.FaStyle;

            if (style == FaStyles.None)
            {
                if (FaLookup.Regular.ContainsKey(ctrl.FaName))
                    style = FaStyles.Regular;
                else if (FaLookup.Solid.ContainsKey(ctrl.FaName))
                    style = FaStyles.Solid;
                else if (FaLookup.Light.ContainsKey(ctrl.FaName))
                    style = FaStyles.Light;
                else if (FaLookup.Duotone.ContainsKey(ctrl.FaName))
                    style = FaStyles.Duotone;
                else if (FaLookup.Brands.ContainsKey(ctrl.FaName))
                    style = FaStyles.Brands;
            }

            if (style == FaStyles.Solid)
            {
                ctrl._placeholder.FontFamily = _Solid;

                if (FaLookup.Solid.ContainsKey(ctrl.FaName))
                    ctrl._placeholder.Text = FaLookup.Solid[ctrl.FaName].ToString();
            }
            else if (style == FaStyles.Regular)
            {
                ctrl._placeholder.FontFamily = _Regular;

                if (FaLookup.Regular.ContainsKey(ctrl.FaName))
                    ctrl._placeholder.Text = FaLookup.Regular[ctrl.FaName].ToString();
            }
            else if (style == FaStyles.Light)
            {
                ctrl._placeholder.FontFamily = _Light;

                if (FaLookup.Light.ContainsKey(ctrl.FaName))
                    ctrl._placeholder.Text = FaLookup.Light[ctrl.FaName].ToString();
            }
            else if (style == FaStyles.Duotone)
            {
                ctrl._placeholder.FontFamily = _Duotone;

                if (FaLookup.Duotone.ContainsKey(ctrl.FaName))
                    ctrl._placeholder.Text = FaLookup.Duotone[ctrl.FaName].ToString();
            }
            else if (style == FaStyles.Brands)
            {
                ctrl._placeholder.FontFamily = _Brands;

                if (FaLookup.Brands.ContainsKey(ctrl.FaName))
                    ctrl._placeholder.Text = FaLookup.Brands[ctrl.FaName].ToString();
            }
        }
    }
}
