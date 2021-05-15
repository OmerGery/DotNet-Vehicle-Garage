namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private VehicleOwner m_Owner;
        private GarageEnums.eFixState m_FixState;
        private Vehicle m_VehicleInGarage;

        public VehicleOwner Owner
        {
            get
            {
                return m_Owner;
            }
        }

        public GarageVehicle(string i_OwnerName, string i_PhoneNumber, Vehicle i_VehicleInGarage)
        {
            m_Owner = new VehicleOwner(i_OwnerName, i_PhoneNumber);
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

        public override string ToString()
        {
            string details = string.Format(
@"Vehicle fix state: {0}
",
m_FixState);
            details += m_Owner.ToString() + VehicleInGarage.ToString();
            return details;
        }
    }
}
