using PlanningPoker.Common.Enums;
using PlanningPoker.Utility;
using PlanningPoker.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Theme = PlanningPoker.Styles.Styles;

namespace PlanningPoker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : MasterDetailPage
    {
        public HomeView()
        {
            this.InitializeComponent();

            Theme.Init(Themes.Light);

            this.Detail = new NavigationPage(new CardSelectionView()) { Style = (Style)ResourceUtility.GetResource("CardSelectionBarBackgroundColor") };
        }

        private void Item_Clicked(object sender, System.EventArgs e)
        {
            if (e is TappedEventArgs item)
            {
                if (this.BindingContext is HomeViewModel viewModel)
                {
                    viewModel.UpdateCards((Menus)item.Parameter);
                }

                this.IsPresented = false;
            }
        }

        private void StandardCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            DrawCanvas(standard_skia.Height, args, Color.FromHex("#436499"), Color.FromHex("#3d5d90"), Color.FromHex("#355383"));
        }

        private void TShirtCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            DrawCanvas(tshirt_skia.Height, args, Color.FromHex("#3c556d"), Color.FromHex("#33475c"), Color.FromHex("#2c3e50"));
        }

        private void FibonacciCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            DrawCanvas(fibonacci_skia.Height, args, Color.FromHex("#4f4f8b"), Color.FromHex("#48488b"), Color.FromHex("#40407a"));
        }

        protected static void DrawCanvas(double height, SKPaintSurfaceEventArgs args, Color primary, Color secondary, Color tertiary)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            canvas.DrawRect(info.Rect, new SKPaint() { Color = primary.ToSKColor() });

            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width - (int)height, 0);
                path.LineTo(0, info.Height * .8f);
                path.Close();
                canvas.DrawPath(path, new SKPaint() { Color = secondary.ToSKColor() });
            }

            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width - ((int)height * 2f), 0);
                path.LineTo(0, info.Height * .6f);
                path.Close();
                canvas.DrawPath(path, new SKPaint() { Color = tertiary.ToSKColor() });
            }
        }
    }
}