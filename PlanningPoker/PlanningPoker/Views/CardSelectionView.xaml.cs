using PlanningPoker.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanningPoker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardSelectionView : ContentPage
    {
        public CardSelectionView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            if (sender is Button button)
            {
                if (this.BindingContext is HomeViewModel viewModel)
                {
                    Vibration.Vibrate(100);
                    viewModel.SelectedCard = button.CommandParameter as string;
                    viewModel.IsTapToReveal = true;
                }
            }
        }

        private void CardCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            DrawCanvas(args, Color.FromHex("#e0eafc"), Color.FromHex("#cfdef3"), Color.Transparent);
        }

        protected static void DrawCanvas(SKPaintSurfaceEventArgs args, Color primary, Color secondary, Color tertiary)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width / 2, 0);
                path.LineTo(0, info.Width / 2);
                path.Close();
                canvas.DrawPath(path, new SKPaint() { Color = primary.ToSKColor() });
            }

            using (SKPath path = new SKPath())
            {
                path.MoveTo(info.Width, info.Height);
                path.LineTo(info.Width / 2, info.Height);
                path.LineTo(info.Height, info.Width / 2);
                path.Close();
                canvas.DrawPath(path, new SKPaint() { Color = secondary.ToSKColor() });
            }
        }
    }
}