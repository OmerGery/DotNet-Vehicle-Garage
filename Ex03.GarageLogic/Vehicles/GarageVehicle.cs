using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private string m_OwnerName;
        private string m_PhoneNumber;
        private GarageEnums.eFixState m_FixState;
        private Vehicle m_VehicleInGarage;

        public GarageVehicle(string i_OwnerName, string i_PhoneNumber, Vehicle i_VehicleInGarage)
        {
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_FixState = GarageEnums.eFixState.BeingFixed;
            m_VehicleInGarage = i_VehicleInGarage;
        }

        public GarageEnums.eFixState FixState
        {
            get
            {
                return m_FixState;
            }
            set
            {
                m_FixState = value;
            }

        }
        public Vehicle VehicleInGarage
        {
            get
            {
                return m_VehicleInGarage;
            }
        }
    }
}
