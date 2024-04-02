using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRQAndroid.Controls
{
    public class CircleGraphDrawable : IDrawable
    {
        private CircleGraph _circleGraph;

        public CircleGraphDrawable(CircleGraph circleGraph)
        {
            _circleGraph = circleGraph;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var width = dirtyRect.Width;
            var height = dirtyRect.Height;

            var sections = _circleGraph.DataProvider?.Invoke();
            if (sections != null)
            {
                _circleGraph.DrawSections(canvas, width, height, sections);
            }
        }
    }
}
