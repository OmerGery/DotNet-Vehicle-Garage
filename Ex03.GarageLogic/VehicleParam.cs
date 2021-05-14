using System;

namespace Ex03.GarageLogic
{
    public class VehicleParam
    {
        private string m_Name;
        public string Name
        {
            get
            {
                return m_Name;
            }
        }
        private string m_FriendlyName;
        public string FriendlyName
        {
            get
            {
                return m_FriendlyName;
            }
        }
        private object m_Value;
        public object Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
            }
        }
        private Type m_Type;
        public Type Type
        {
            get
            {
                return m_Type;
            }
        }

        public VehicleParam(string i_Name,string i_FriendlyName, Type i_Type )
        {
            m_Name = i_Name;
            m_FriendlyName = i_FriendlyName;
            m_Value = null;
            m_Type = i_Type;
        }

    }
}
