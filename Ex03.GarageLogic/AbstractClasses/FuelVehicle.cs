using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        private float m_MaxFuelLitersCapacity;
        private GarageEnums.eFuelType m_FuelType;
        private float m_LitersOfFuelLeft;

        public static new List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>()
                       {
                           new VehicleParam("m_LitersOfFuelLeft", "Liters of Fuel Left", typeof(float)),
                       };
        }

        public float MaxFuelLitersCapacity
        {
            get
            {
                return m_MaxFuelLitersCapacity;
            }
        }

        public float LitersOfFuelLeft
        {
            get
            {
                return m_LitersOfFuelLeft;
            }

            set
            {
                if(value > m_MaxFuelLitersCapacity)
                {
                    throw new ValueOutOfRangeException(0, m_MaxFuelLitersCapacity, "Fuel's liters capacity");
                }

                m_LitersOfFuelLeft = value;
            }
        }

        public void Init(Dictionary<string, VehicleParam> i_Parameters, float i_MaxLitersOfFuel, int i_MaxPsiOfWheels, int i_AmountOfWheels, GarageEnums.eFuelType i_FuelType)
        {
            Init(i_Parameters, i_MaxPsiOfWheels, i_AmountOfWheels);
            m_MaxFuelLitersCapacity = i_MaxLitersOfFuel;
            LitersOfFuelLeft = (float)i_Parameters["m_LitersOfFuelLeft"].Value;
            m_FuelType = i_FuelType;
        }

        public GarageEnums.eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }
        
        public override float EnergyOfPrecentageLeft
        {
            get
            {
                return m_LitersOfFuelLeft * 100 / m_MaxFuelLitersCapacity;
            }
        }

        public override string ToString()
        {
            string baseDetails = base.ToString();
            string details = string.Format(
@"Liters of Fuel Left: {0}
Liters of Fuel Maximum capacity: {1}
Fuel Type: {2}
",
                m_LitersOfFuelLeft,
                m_MaxFuelLitersCapacity,
                m_FuelType);
            return baseDetails + details;
        }

        public void Refuel(float i_LitersOfFuelToAdd)
        {
            if(i_LitersOfFuelToAdd + m_LitersOfFuelLeft > m_MaxFuelLitersCapacity || i_LitersOfFuelToAdd <= 0)
            {
                throw new ValueOutOfRangeException(0, m_MaxFuelLitersCapacity - m_LitersOfFuelLeft, "Fuel liters to add");
            }
            
            LitersOfFuelLeft += i_LitersOfFuelToAdd;
        }
    }
}
