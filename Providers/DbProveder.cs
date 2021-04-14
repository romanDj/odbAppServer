using gasDiesel.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gasDiesel.Providers
{
    public class DbProveder : IDbContext
    {
        const string GasDieselContextKey = "GasDieselContext";
        /// <summary>
        /// Контекст БД
        /// </summary>
        public GasDieselContext GasDieselContext
        {
            get
            {
                if (HttpContext.Current == null)
                    return new GasDieselContext();
                if (HttpContext.Current.Items[GasDieselContextKey] == null)
                    HttpContext.Current.Items[GasDieselContextKey] = new GasDieselContext();
                return (GasDieselContext)HttpContext.Current.Items[GasDieselContextKey];
            }
        }
    }
}