﻿namespace Domain.Dal.Repositories.Abstract
{
    using System.Collections.Generic;

    using Domain.Models;

    public interface IDbRepository
    {
        void Create(Database database);

        void Delete(string dbName);

        Database GetByName(string dbName);

        IEnumerable<string> GetAllNames();

        void Update(Database database);
    }
}