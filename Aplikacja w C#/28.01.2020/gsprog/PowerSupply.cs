using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace gsprog
{
    class PowerSupply
    {
        private bool _Mode;
        private bool _Enable;
        private double _Voltage;
        private double _Current;
        private double _Power;
        private double _OverCurrent;
        private string comm;
        private int _Index;
        private bool result;
        private SerialPort Port;

        public PowerSupply(int ind, SerialPort Port)
        {
            this.Port = Port;
            Set_En_DisPowsupp(true);
            SetModePowsupp(false);
            SetVoltagePowsupp(2);
            SetCurrPowsupp(0.10);
            SetPowPowsupp(5);
            SetOvCurrPowsupp(0.10);
            this._Index = ind;

        }



        public bool Set_En_DisPowsupp(bool oper)
        {

            if (oper)   //właczanie gdy oper == true
            {
                comm = "#0z" + _Index + "x0/*/;";
                _Enable = true;
            }
            if (oper == false)   //wyłaczanie gdy oper == false
            {
                comm = "#0z" + _Index + "x1/*/;";
                _Enable = false;
            }

            if (Port.IsOpen)
            {
                Port.WriteLine(comm);
            }


            return this.result;
        }


        public bool SetModePowsupp(bool mode)
        {
            if (mode == false)   //trub CV _Mode = false
            {
                comm = "#0z" + _Index + "tv/*/;";
                _Mode = false;
            }
            if (mode)     //tryb CC   _Mode = true
            {
                comm = "#0z" + _Index + "tc/*/;";
                _Mode = true;
            }


            if (Port.IsOpen)
            {
                Port.WriteLine(comm);
            }

            return result;
        }





        public bool SetCurrPowsupp(double current)
        {
            comm = "#0zc" + _Index + "/*" + current + "/;";
            _Current = current;

            if (Port.IsOpen)
            {
                Port.WriteLine(comm);
            }

            return result;
        }

        public bool SetVoltagePowsupp(double voltage)
        {
            comm = "#0zv" + _Index + "/*" + voltage + "/;";
            _Voltage = voltage;

            if (Port.IsOpen)
            {
                Port.WriteLine(comm);
            }

            return result;
        }

        public bool SetPowPowsupp(double power)
        {
            comm = "#0zp" + _Index + "/*" + power + "/;";
            _Power = power;


            if (Port.IsOpen)
            {
                Port.WriteLine(comm);
            }
            return result;
        }

        public bool SetOvCurrPowsupp(double OverCurrent)
        {

            comm = "#0zc" + _Index + "/*" + OverCurrent + "/;";
            _OverCurrent = OverCurrent;


            if (Port.IsOpen)
            {
                Port.WriteLine(comm);
            }

            return result;
        }


    }
}
