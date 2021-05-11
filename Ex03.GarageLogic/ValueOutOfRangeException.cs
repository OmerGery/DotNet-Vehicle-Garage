using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(
                string.Format(
                    "An error has occured, The selection must be between {0} and {1}",
                    i_MinValue,
                    i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
