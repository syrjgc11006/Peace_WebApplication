using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// ÓÑÇéÁ´½Ó
    /// </summary>
    public partial class pl_link : BaseEntity<int>
    {
        public string site_path { get; set; }
        public string title { get; set; }
        public string user_name { get; set; }
        public string user_tel { get; set; }
        public string email { get; set; }
        public string site_url { get; set; }
        public string img_url { get; set; }
        public int is_image { get; set; }
        public int sort_id { get; set; }
        public byte is_red { get; set; }
        public byte is_lock { get; set; }
        public Nullable<System.DateTime> add_time { get; set; }
    }
}
