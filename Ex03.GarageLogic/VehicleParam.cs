using System;

namespace Ex03.GarageLogic
{
    public class VehicleParam
    {
        public string m_Name { get; set; }
        public string m_FriendlyName { get; set; }
        public object m_Value { get; set; }
        public Type m_Type { get; set; }

        public VehicleParam(string i_Name,string i_FriendlyName,object i_Value, Type i_Type )
        {
            m_Name = i_Name;
            m_FriendlyName = i_FriendlyName;
            m_Value = i_Value;
            m_Type = i_Type;
        }
    }
}
