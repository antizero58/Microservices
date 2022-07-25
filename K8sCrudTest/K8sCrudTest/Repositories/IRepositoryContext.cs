using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace K8sCrudTest
{
    public interface IRepositoryContext
    {
        public DbContext DataContext { get; }
    }
}
