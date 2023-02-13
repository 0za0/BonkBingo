using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BionicleHeroesBingoGUI.Helpers
{
    internal static class ImageHelpers
    {
        public static RenderTargetBitmap GetImage(Panel view)
        {
            System.Windows.Size size = new System.Windows.Size((int)view.ActualWidth, (int)view.ActualHeight);
            if (size.IsEmpty)
                return null;

            RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);

            DrawingVisual drawingvisual = new DrawingVisual();
            using (DrawingContext context = drawingvisual.RenderOpen())
            {
                context.DrawRectangle(new VisualBrush(view), null, new Rect(new System.Windows.Point(0, 0), size));
                context.Close();
            }

            result.Render(drawingvisual);
            return result;
        }
        public static RenderTargetBitmap CopyManyUiElementToClipboard(List<FrameworkElement> elements)
        {
            double totalWidth = elements.Sum(element => element.ActualWidth);
            double totalHeight = elements.Max(element => element.ActualHeight);

            var size = new System.Windows.Size(totalWidth, totalHeight);
            var rectangleFrame = new System.Windows.Shapes.Rectangle
            {
                Width = (int)size.Width,
                Height = (int)size.Height,
                Fill = System.Windows.Media.Brushes.White
            };

            rectangleFrame.Arrange(new Rect(size));
            var renderBitmap = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96d, 96d, PixelFormats.Pbgra32);
            renderBitmap.Render(rectangleFrame);

            var xPointCordinate = 0.0;
            elements.ForEach(element =>
            {
                var drawingContext = new DrawingVisual();

                using (DrawingContext draw = drawingContext.RenderOpen())
                {
                    var visualBrush = new VisualBrush(element);
                    var elementSize = new System.Windows.Size(element.ActualWidth, element.ActualHeight);
                    draw.DrawRectangle(visualBrush, null, new Rect(new System.Windows.Point(xPointCordinate, 0), elementSize));
                }

                xPointCordinate += element.ActualWidth;
                renderBitmap.Render(drawingContext);
            });

            return renderBitmap;
        }
        public static void SaveAsPng(RenderTargetBitmap src, Stream outputStream)
        {
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(src));

            encoder.Save(outputStream);
        }
    }
}
