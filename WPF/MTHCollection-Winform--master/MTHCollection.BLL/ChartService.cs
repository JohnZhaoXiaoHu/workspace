using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.BLL
{

    public class ChartService
    {
        public static Scatter AddData<Tx, Ty>(Plot plot, List<Tx> tx, List<Ty> ty, System.Drawing.Color color)
        {
          
          return  plot.Add.Scatter(tx,ty, color: ScottPlot.Color.FromColor(color));
        }

        public static Scatter AddData<Tx, Ty>(Plot plot, List<Tx> tx, List<Ty> ty)
        {

            return plot.Add.Scatter(tx, ty);
        }

        public void SetScatterText(Scatter scatter, string text)
        {
            scatter.LegendText= text;
        }
    }
}
