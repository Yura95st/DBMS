﻿namespace Domain.Models.DataTypes.Concrete
{
    public class ComplexDoubleDataType : ComplexDataType
    {
        public ComplexDoubleDataType()
            : base(@"\d*(\.\d+)?")
        {
        }
    }
}