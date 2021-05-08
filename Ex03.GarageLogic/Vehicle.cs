using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercentageLeft;
        private List<Tire> m_Tires;

        //public Vehicle(string i_ModelName,string i_LicenseNumber,float i_EnergyPercentageLeft,int i_TirePressure,int i_AmountOfTires)
        //{
        //    m_Tires = new List<Tire>(i_AmountOfTires);
        //    //foreach(var tire in m_Tires)
        //    //{
        //    //    ("default", i_TirePressure);
        //    //}
        //}
        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }
        public List<Tire> Tires
        {
            get
            {
                return m_Tires;
            }
        }
    }
}
