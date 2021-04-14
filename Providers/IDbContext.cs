using gasDiesel.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasDiesel.Providers
{
    public interface IDbContext
    {
        GasDieselContext GasDieselContext { get; }
    }
}
