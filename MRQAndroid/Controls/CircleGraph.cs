using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;

namespace MRQAndroid.Controls
{
    public class CircleGraphSection
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Color Color { get; set; }
    }

    public class CircleGraph : GraphicsView, IDrawable
    {
        public List<CircleGraphSection> Sections { get; set; } = new List<CircleGraphSection>();

        public CircleGraph()
        {
            Drawable = this;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float strokeWidth = 40f; // Adjusted for a thicker donut chart
            float outerRadius = Math.Min(dirtyRect.Width, dirtyRect.Height) / 2;
            float innerRadius = outerRadius - strokeWidth; // Create a donut hole
            float centerX = dirtyRect.Width / 2;
            float centerY = dirtyRect.Height / 2;

            float startAngle = -90; // Starting from the top

            foreach (var section in Sections)
            {
                // Calculate sweep angle for each section
                float sweepAngle = (section.Value / 100f) * 360; // Assuming total is 100 for simplicity

                // Set paint style to stroke to draw the outline of the section
                canvas.StrokeSize = strokeWidth;
                canvas.StrokeColor = section.Color;

                // Draw the outer arc of the donut section
                canvas.DrawArc(centerX - outerRadius, centerY - outerRadius, outerRadius * 2, outerRadius * 2, startAngle, sweepAngle, false, false);

                // Optionally draw the inner arc if you want to clear the center (this creates the donut hole)
                // You'd typically set the blend mode to clear, but this depends on the capabilities of the graphics library

                // Draw labels and icons here
                // You'll need to calculate the position for each label and icon based on the angles

                startAngle += sweepAngle;
            }

            // Draw the central text here
            // Measure the text and draw it at the center of the chart
        }
    }
}


//{
//    public class CircleGraphSection
//    {
//        public string Name { get; set; }
//        public int Value { get; set; }
//        public Color Color { get; set; }
//    }

//    public class CircleGraph : GraphicsView
//    {
//        // public Func<List<CircleGraphSection>> DataProvider { set; get; } This approach uses a delegate (Func<T>) that allows for dynamic data retrieval. It doesn't initialize the data immediately but instead provides a mechanism to fetch the data dynamically when needed.
//        // public List<CircleGraphSection> Sections { get; set; } = new List<CircleGraphSection> ();

//        public void DrawSections(ICanvas canvas, float width, float height, List<CircleGraphSection> sections)
//        {
//            float strokeWidth = 10f;
//            float radius = (Math.Min(width, height) - strokeWidth * 2) / 2;
//            float cx = width / 2;
//            float cy = height / 2;

//            var rectArc = new Rect(cx - radius, cy - radius, radius * 2, radius * 2);

//            float startAngle = -90;  // Start from top

//            foreach (var section in sections)
//            {
//                canvas.StrokeColor = section.Color;
//                canvas.StrokeSize = strokeWidth;

//                float sweepAngle = (float)section.Value / (float)100 * 360;  // calculate the sweep angle

//                canvas.DrawArc((float)rectArc.Left, (float)rectArc.Top, (float)rectArc.Width, (float)rectArc.Height, startAngle, sweepAngle, true, true); startAngle += sweepAngle; // incrementing startAngle for next item
//            }
//        }
//    }
//}






/*
namespace MRQAndroid.Controls
{
    public class Section
    {
        public string Name { get; set; }
        public double Value { get; set; } // Assuming Value is a percentage of the total 360 degrees
        public Color Color { get; set; }
        public ImageSource Icon { get; set; }
    }

    public class CircleGraph : View, IDrawable
    {
        public Func<List<Section>> DataProvider { get; set; }

        public double StrokeWidth { get; set; } = 10; // Default stroke width
        public bool IsDonut { get; set; } = false; // If true, draw a donut chart; else, draw a full circle chart
        public double DonutInnerRadiusRatio { get; set; } = 0.5; // Ratio of inner radius to outer radius for donut chart

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var sections = DataProvider?.Invoke();

            if (sections != null && sections.Any())
            {
                if (IsDonut)
                {
                    DrawDonutSections(canvas, dirtyRect, sections);
                }
                else
                {
                    DrawCircleSections(canvas, dirtyRect, sections);
                }
            }
        }

        private void DrawCircleSections(ICanvas canvas, RectF dirtyRect, List<Section> sections)
        {
            float startAngle = -90; // Start from top (-90 degrees)

            foreach (var section in sections)
            {
                DrawSection(canvas, dirtyRect, startAngle, section);
                startAngle += (float)(section.Value / 100.0 * 360.0); // Assuming Value is a percentage
            }
        }

        private void DrawDonutSections(ICanvas canvas, RectF dirtyRect, List<Section> sections)
        {
            float startAngle = -90;  // Start from the top (-90 degrees)

            float outerRadius = Math.Min(dirtyRect.Width, dirtyRect.Height) / 2;
            float innerRadius = (float)(outerRadius * DonutInnerRadiusRatio);

            foreach (var section in sections)
            {
                float sweepAngle = (float)(section.Value / 100.0 * 360.0); // Calculating sweep angle based on the section value percentage of the total

                // Draw the outer arc for the section
                canvas.StrokeSize = StrokeWidth;
                canvas.StrokeColor = section.Color;
                float adjustedOuterRadius = outerRadius - StrokeWidth / 2; // Adjust for stroke size
                var outerArcRect = new RectF(
                    dirtyRect.Center.X - adjustedOuterRadius,
                    dirtyRect.Center.Y - adjustedOuterRadius,
                    adjustedOuterRadius * 2,
                    adjustedOuterRadius * 2);
                canvas.DrawArc(outerArcRect, startAngle, sweepAngle, false);

                // Draw the inner arc for the section
                float adjustedInnerRadius = innerRadius + StrokeWidth / 2; // Adjust for stroke size
                var innerArcRect = new RectF(
                    dirtyRect.Center.X - adjustedInnerRadius,
                    dirtyRect.Center.Y - adjustedInnerRadius,
                    adjustedInnerRadius * 2,
                    adjustedInnerRadius * 2);
                // Drawing the inner arc with reverse sweep angle to create a donut-like shape
                canvas.DrawArc(innerArcRect, startAngle + sweepAngle, -sweepAngle, false);

                startAngle += sweepAngle; // Incrementing startAngle for the next section
            }

            // Optionally, you can place icons or text labels representing each section
            // This part illustrates a basic approach for placing icons; more complex positioning might require adjustments
            startAngle = -90; // Resetting the start angle for icon placements
            foreach (var section in sections)
            {
                float sweepAngle = (float)(section.Value / 100.0 * 360.0);
                if (section.Icon != null)
                {
                    // Calculate the angle to place the icon
                    float iconAngle = startAngle + sweepAngle / 2;
                    float iconDistance = (innerRadius + outerRadius) / 2; // Distance from center to place the icon

                    // Convert angle to radians for X and Y calculations
                    double angleRadians = Math.PI * iconAngle / 180.0;
                    float iconX = dirtyRect.Center.X + (float)(iconDistance * Math.Cos(angleRadians)) - 10; // Assuming icon size to be 20x20
                    float iconY = dirtyRect.Center.Y + (float)(iconDistance * Math.Sin(angleRadians)) - 10;

                    // Assuming you have a method to draw the icon using the calculated coordinates
                    DrawIcon(canvas, section.Icon, new PointF(iconX, iconY));
                }

                startAngle += sweepAngle;
            }
        }

        // Placeholder for the DrawIcon method
        private void DrawIcon(ICanvas canvas, ImageSource icon, PointF position)
        {
            // Depending on your graphics library, you may need to load the image resource and draw it at the specified position.
            // This is a simplified placeholder to indicate where and how icons might be drawn.
            // Actual implementation may involve loading the image into a drawable format and rendering it on the canvas.
            canvas.DrawImage(icon, position.X, position.Y, 20, 20);
        }
    }
}
*/

