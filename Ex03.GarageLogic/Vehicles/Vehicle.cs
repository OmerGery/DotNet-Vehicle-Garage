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
        private List<Tire> m_Tires;

        public Vehicle(Dictionary<string, VehicleParam> i_Parameters, int i_MaxTirePressure, int i_AmountOfTires)
        {
            m_Tires = new List<Tire>(i_AmountOfTires);

            for (int i = 0; i < i_AmountOfTires; i++)
            {
                Tire tireToAdd = new Tire((string)i_Parameters["m_TireManufacturerName"].Value, (float)i_Parameters["m_CurrentPsiTirePressure"].Value,  i_MaxTirePressure);
                tireToAdd.CurrentPsiTirePressure = (float)i_Parameters["m_CurrentPsiTirePressure"].Value;
                m_Tires.Add(tireToAdd);
            }

            m_ModelName = (string)i_Parameters["m_ModelName"].Value;
            m_LicenseNumber = (string)i_Parameters["m_LicenseNumber"].Value;
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

        public override string ToString()
        {
            string details = string.Format(
@"Model Name: {0}
License Number: {1}
Amount Of Wheels: {2} 
",
m_ModelName,
m_LicenseNumber,
m_Tires.Count);
            details += m_Tires[0].ToString();
            return details;
        }
    }
}
