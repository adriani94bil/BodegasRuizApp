using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasRuizApp.Services
{
    public class Servicio
    {
        public bool IsUnderage(DateTime fechaNacimiento)
        {
            bool cond;
            int z;
            string n1 = fechaNacimiento.ToString("yyyyMMdd");
            int today = Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd"));
            z = (today - Convert.ToInt32(n1)) / 10000;
            if (z >= 18)
            {
                cond = true;
            }
            else
            {
                cond = false;
            }
            return cond;

        }
        public double FinalPrice(double preciostd, double mul1,double mul2)
        {
            double z;
            z = preciostd * mul1 * mul2;
            return z;
        }
        public string POGen()
        {
            string po;
            Random random = new Random();
            DateTime date = DateTime.Now;
            string dats = date.ToString("yyyy/MM/dd");
            string num = Convert.ToString(random.Next(0, 99));
            po = dats + num;
            return po;

        }
    }
}
