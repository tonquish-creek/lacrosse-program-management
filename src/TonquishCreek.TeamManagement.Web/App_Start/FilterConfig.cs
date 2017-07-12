using System;
using System.Web.Mvc;

namespace TonquishCreek.TeamManagement.Web
{
    public sealed class FilterConfig
    {
        #region Constructor(s)
        private FilterConfig()
        {
        }
        #endregion

        #region Public Method(s)
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            filters.Add(new HandleErrorAttribute());
        }
        #endregion
    }
}
