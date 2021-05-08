using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        public enum eFuelType
        {
            Soler,
            Octan96,
            Octan95,
            Octan98
        }

        private float m_LitersOfFuelLeft;
        private float m_MaxFuelLitersCapacity;
        public void Refuel(float i_LitersOfFuelToAdd, eFuelType i_FuelType)
        {
            /// !!!! EXCEPTIONS 
            m_MaxFuelLitersCapacity += i_LitersOfFuelToAdd;
        }
    }
}
