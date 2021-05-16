using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        private readonly float r_MaxFuelLitersCapacity;
        private readonly GarageEnums.eFuelType r_FuelType;
        private float m_LitersOfFuelLeft;

        public float MaxFuelLitersCapacity
        {
            get
            {
                return r_MaxFuelLitersCapacity;
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
                if(value > r_MaxFuelLitersCapacity)
                {
                    throw new ValueOutOfRangeException(0, r_MaxFuelLitersCapacity, "Fuel's liters capacity");
                }

                m_LitersOfFuelLeft = value;
            }
        }

        public GarageEnums.eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public FuelVehicle(Dictionary<string, VehicleParam> i_Parameters, float i_MaxLitersOfFuel, int i_MaxTirePressure, int i_AmountOfWheels, GarageEnums.eFuelType i_FuelType) : 
            base(i_Parameters, i_MaxTirePressure, i_AmountOfWheels)
        {
            r_MaxFuelLitersCapacity = i_MaxLitersOfFuel;
            LitersOfFuelLeft = (float)i_Parameters["m_LitersOfFuelLeft"].Value;
            r_FuelType = i_FuelType;
        }

        public override float EnergyOfPrecentageLeft
        {
            get
            {
                return m_LitersOfFuelLeft * 100 / r_MaxFuelLitersCapacity;
            }
        }

        public static new List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>()
                       {
                           new VehicleParam("m_LitersOfFuelLeft", "Liters of Fuel Left", typeof(float)),
                       };
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
                r_MaxFuelLitersCapacity,
                r_FuelType);
            return baseDetails + details;
        }

        public void Refuel(float i_LitersOfFuelToAdd)
        {
            if(i_LitersOfFuelToAdd + m_LitersOfFuelLeft > r_MaxFuelLitersCapacity || i_LitersOfFuelToAdd <= 0)
            {
                throw new ValueOutOfRangeException(0, r_MaxFuelLitersCapacity - m_LitersOfFuelLeft, "Fuel liters to add");
            }
            
            LitersOfFuelLeft += i_LitersOfFuelToAdd;
        }
    }
}
