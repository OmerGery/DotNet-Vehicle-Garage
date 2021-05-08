using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Truck : FuelVehicle
    {
        protected bool m_ContainsToxic;
        protected float m_MaxCarryWeight;
    }
}
