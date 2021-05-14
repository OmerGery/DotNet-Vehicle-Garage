using System;
using System.Runtime.Remoting.Messaging;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;

        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        private float m_MinValue;

        public float MinValue
        {
            get { return m_MinValue; }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_TypeOutOfRange)
            : base(
                string.Format(
                    "An error has occured, The {0} must be between {1} and {2}",
                    i_TypeOutOfRange,
                    i_MinValue,
                    i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
