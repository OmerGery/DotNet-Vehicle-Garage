using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {


        private float m_LitersOfFuelLeft;
        private float m_MaxFuelLitersCapacity;

        public float LitersOfFuelLeft
        {
            get
            {
                return m_LitersOfFuelLeft;
            }
            set
            {
                if(value > m_MaxFuelLitersCapacity || value < 0)
                {
                    throw new ValueOutOfRangeException(0, m_MaxFuelLitersCapacity, "Fuel's liters capacity");
                }

                m_LitersOfFuelLeft = value;
            }
        }

        private GarageEnums.eFuelType m_FuelType;

        public GarageEnums.eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }
        public FuelVehicle(Dictionary<string, VehicleParam> i_Parameters, float i_MaxLitersOfFuel, int i_MaxTirePressure,int i_AmountOfWheels) : 
            base(i_Parameters, i_MaxTirePressure, i_AmountOfWheels)
        {
            m_MaxFuelLitersCapacity = i_MaxLitersOfFuel;
            LitersOfFuelLeft = (float)i_Parameters["m_LitersOfFuelLeft"].Value;
            m_FuelType = (GarageEnums.eFuelType)i_Parameters["m_FuelType"].Value;
        }

        public override float EnergyOfPrecentageLeft
        {
            get
            {
                return m_LitersOfFuelLeft * 100 / m_MaxFuelLitersCapacity;
            }
        }

        public static List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>()
                       {
                           new VehicleParam("m_LitersOfFuelLeft", "Liters of Fuel Left", typeof(float)),
                           new VehicleParam("m_FuelType", "Fuel Type", typeof(GarageEnums.eFuelType)),
                       };
        }

        public override string ToString()
        {
            string baseDetails = base.ToString();
            string details = string.Format(
@"Liters of Fuel Left: {0}
Liters of Fuel Maximum capacity: {1}
",
                m_LitersOfFuelLeft,
                m_MaxFuelLitersCapacity);
            return baseDetails + details;
        }
    }
}
