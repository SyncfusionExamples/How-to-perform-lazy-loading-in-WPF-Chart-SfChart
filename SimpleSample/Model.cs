using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSample
{
    public class Model
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
        public Model(double xValue, double value)  
        {
            XValue = xValue;
            YValue = value;
        }
    }
}
