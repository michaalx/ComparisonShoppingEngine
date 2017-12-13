using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataBase.Context;
using DataBase.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataBase.Repositories
{
    public class RecordRepository : Repository<Record>
    {
        public RecordRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public void Sth(Record x)
        {
            Entity.Add(x);
        }
        //TODO:
        //Requests needed to implement functionality.
    }
}
