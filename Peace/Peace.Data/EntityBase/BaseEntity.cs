using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Data
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class BaseEntity<TId>
    {
        [Key]
        public TId id { get; set; }  //主键 

        [Display(Name = "创建人Id")]
        public int? CreaterId { get; set; }
       
        [Display(Name = "创建人名称")]
        public string CreaterName { get; set; }

        [Display(Name = "更新人Id")]
        public int? UpdaterId { get; set; }

        [Display(Name = "更新人名称")]
        public string UpdaterName { get; set; }

        [Display(Name = "创建时间")]      
        public DateTime? CreateTime { get; set; }

        [Display(Name = "更新时间")]
        public DateTime? UpdateTime { get; set; }

    }
}
