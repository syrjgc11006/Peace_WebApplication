using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// Í¼Æ¬Ïà²á
    /// </summary>
    public partial class pl_article_albums:BaseEntity<int>
    {
        /// <summary>
        /// ÎÄÕÂID
        /// </summary>
        public Nullable<int> article_id { get; set; }

        /// <summary>
        /// ËõÂÔÍ¼µØÖ·
        /// </summary>
        public string thumb_path { get; set; }

        /// <summary>
        /// Ô­Í¼µØÖ·
        /// </summary>
        public string original_path { get; set; }

        /// <summary>
        /// Í¼Æ¬ÃèÊö
        /// </summary>
        public string remark { get; set; }
    }
}
