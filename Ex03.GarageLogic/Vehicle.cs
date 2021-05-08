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
