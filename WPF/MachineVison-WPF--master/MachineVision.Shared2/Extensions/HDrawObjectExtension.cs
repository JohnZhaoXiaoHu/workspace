using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using MachineVision.Core.TeamplateMatch;
using MachineVision.Core.TeamplateMatch.Enum;

namespace MachineVision.Shared2.Extensions
{
    public enum DrawShape
    {
        Rectangle,
        Circle,
        Ellipse,
        Polygon,
        Region
    }

    public static class HDrawObjectExtension
    {
        public static HTuple[] GetHtuples(
            this HDrawingObject drawingObject,
            DrawShape shapeType
        ) 
        {
            HTuple[] hTuples = null;
            switch (shapeType)
            {
                case DrawShape.Rectangle:
                    hTuples = new HTuple[4];
                    hTuples[0] = drawingObject.GetDrawingObjectParams("row1");
                    hTuples[1] = drawingObject.GetDrawingObjectParams("column1");
                    hTuples[2] = drawingObject.GetDrawingObjectParams("row2");
                    hTuples[3] = drawingObject.GetDrawingObjectParams("column2");
                    break;
            }
            return hTuples;
        }
    }
}
