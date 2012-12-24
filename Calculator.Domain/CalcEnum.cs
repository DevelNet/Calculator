using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain
{
    public enum CalcEnum
    {
        ComCalc,
        FloatCalc,
        IntCalc
    }

    public enum Operations
    {
        Add,
        Remove,
        Divide,
        Multiply,
        Clear,
        Sqrt,
        Modul
    }

    public class CalcChangeState 
    {
       public CalcChangeState()
       {
         calcEnum = CalcEnum.ComCalc;
       }

        private CalcEnum calcEnum;
        public CalcEnum CalcEnum { get { return calcEnum; } }
        public void Change(bool intState,bool doubleState,bool complecsState)
        {
            if(intState==true && doubleState == false && complecsState == false)
            {
                calcEnum=CalcEnum.IntCalc;
                return;
            }
            if (intState == false && doubleState == true && complecsState == false)
            {
                calcEnum = CalcEnum.FloatCalc;
                return;
            }
            if (intState == false && doubleState == false && complecsState == true)
            {
                calcEnum = CalcEnum.ComCalc;
                return;
            }
            throw new MultiStateEror();
         }
    }

    class MultiStateEror:Exception
    {
        public MultiStateEror():base("Eror: MultiState")
        {
        }
    }
    }
