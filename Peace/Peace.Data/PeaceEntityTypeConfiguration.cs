using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public abstract class PeaceEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected PeaceEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        private void PostInitialize()
        {

        }
    }
}
