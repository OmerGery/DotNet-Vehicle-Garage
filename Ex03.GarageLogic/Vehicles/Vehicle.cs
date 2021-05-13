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

        public Vehicle(Dictionary<string, VehicleParam> i_Parameters, int i_MaxTirePressure, int i_AmountOfTires)
        {
            m_Tires = new List<Tire>(i_AmountOfTires);

            for (int i = 0; i < i_AmountOfTires; i++)
            {
                Tire tireToAdd = new Tire((string)i_Parameters["m_TireManufacturerName"].m_Value, i_MaxTirePressure);
                tireToAdd.CurrentPsiTirePressure = (float)i_Parameters["m_CurrentPsiTirePressure"].m_Value;
                m_Tires.Add(tireToAdd);
            }

            m_ModelName = (string)i_Parameters["m_ModelName"].m_Value;
            m_LicenseNumber = (string)i_Parameters["m_LicenseNumber"].m_Value;

        }

        public abstract float EnergyOfPrecentageLeft
        {
            get;
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

        public static List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>()
           {
               new VehicleParam("m_ModelName", "Model Name", typeof(string)),
               new VehicleParam("m_LicenseNumber", "License Number", typeof(string)),
               new VehicleParam("m_TireManufacturerName", "Name of The Tires Manufacturer", typeof(string)),
               new VehicleParam("m_CurrentPsiTirePressure", "Current PSI pressure of tires", typeof(float)),
           };

        }
    }
}
