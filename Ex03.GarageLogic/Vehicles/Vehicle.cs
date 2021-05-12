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

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft, string i_TireManufacturerName, int i_CurrentTirePressure, int i_MaxTirePressure, int i_AmountOfTires)
        {
            m_Tires = new List<Tire>(i_AmountOfTires);
            for(int i=0;i<i_AmountOfTires;i++)
            {
                Tire tireToAdd = new Tire(i_TireManufacturerName, i_MaxTirePressure);
                tireToAdd.CurrentPsiTirePressure = i_CurrentTirePressure;
                m_Tires.Add(tireToAdd);
            }

            m_ModelName = i_ModelName;
            m_EnergyPercentageLeft = i_EnergyPercentageLeft;
            m_LicenseNumber = i_LicenseNumber;

        }

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
