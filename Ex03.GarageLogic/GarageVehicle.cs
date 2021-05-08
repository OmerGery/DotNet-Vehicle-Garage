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
        enum eFixState
        {
            BeingFixed,
            Fixed,
            Payed
        }

        private Vehicle m_Vehicle;
    }
}
