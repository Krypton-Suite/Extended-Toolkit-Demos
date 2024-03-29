﻿using System;
using System.Drawing;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class ShowValueOnHover2 : KryptonForm
    {
        private readonly ScatterPlot MyScatterPlot;
        private readonly MarkerPlot HighlightedPoint;
        private int LastHighlightedIndex = -1;

        public ShowValueOnHover2()
        {
            InitializeComponent();

            // create a scatter plot from some random data and save it
            Random rand = new Random(0);
            int pointCount = 20;
            double[] xs = DataGen.Random(rand, pointCount);
            double[] ys = DataGen.Random(rand, pointCount, multiplier: 1_000);
            MyScatterPlot = formsPlot1.Plot.AddScatterPoints(xs, ys);

            // Add a red circle we can move around later as a highlighted point indicator
            HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
            HighlightedPoint.Color = Color.Red;
            HighlightedPoint.MarkerSize = 10;
            HighlightedPoint.MarkerShape = MarkerShape.OPENCIRCLE;
            HighlightedPoint.IsVisible = false;
        }

        private void formsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            // determine point nearest the cursor
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            double xyRatio = formsPlot1.Plot.XAxis.Dims.PxPerUnit / formsPlot1.Plot.YAxis.Dims.PxPerUnit;
            (double pointX, double pointY, int pointIndex) = MyScatterPlot.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);

            // place the highlight over the point of interest
            HighlightedPoint.X = pointX;
            HighlightedPoint.Y = pointY;
            HighlightedPoint.IsVisible = true;

            // render if the highlighted point chnaged
            if (LastHighlightedIndex != pointIndex)
            {
                LastHighlightedIndex = pointIndex;
                formsPlot1.Refresh();
            }

            // update the GUI to describe the highlighted point
            klblMessage.Text = $"Closest point to ({e.X:N0}, {e.Y:N0}) " +
                          $"is index {pointIndex} ({pointX:N2}, {pointY:N2})";
        }
    }
}
