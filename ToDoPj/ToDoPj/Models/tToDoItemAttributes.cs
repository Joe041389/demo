using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoPj.Models
{

    [Bind(Include ="fTitle,fDate")]

    [MetadataType(typeof(tToDoItemAttributes))]

    public class tToDoItemAttributes
    {
        [Key]
        [Display(Name = "編號")]
        public int fId { get; set; }

        [StringLength(50)]
        [Display(Name = "標題")]
        public string fTitle { get; set; }

        [StringLength(50)]
        [Display(Name = "圖示")]
        public string fImage { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "結案日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fDate { get; set; }
    }
}