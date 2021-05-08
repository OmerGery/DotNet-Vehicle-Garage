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
