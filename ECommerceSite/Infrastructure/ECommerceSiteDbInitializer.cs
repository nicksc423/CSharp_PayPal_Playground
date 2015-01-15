using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerceSite.Infrastructure
{
    public class ECommerceSiteDbInitializer : DropCreateDatabaseAlways<ECommerceSiteDB>
    {
        protected override void Seed(ECommerceSiteDB context)
        {
            base.Seed(context);
        }
    }
}