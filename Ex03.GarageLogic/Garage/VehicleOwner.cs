namespace Ex03.GarageLogic
{
    public class VehicleOwner
    {
        private string m_OwnerName;

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        private string m_PhoneNumber;

        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }
        }

        public VehicleOwner(string i_OwnerName, string i_PhoneNumber)
        {
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
        }

        public override string ToString()
        {
            string details = string.Format(
@"Owner Name: {0}
Phone Number: {1}
",
                m_OwnerName,
                m_PhoneNumber);
            return details;
        }
    }
}
