﻿namespace Domain.Models.DataTypes.Abstract
{
    public interface IDataType
    {
        string DefaultValue
        {
            get;
        }

        bool IsValidValue(string value);
    }
}