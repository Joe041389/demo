namespace ToDoPj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tToDo")]
    public partial class tToDo
    {
        [Key]
        [Display(Name ="編號")]
        public int fId { get; set; }

        [StringLength(50)]
        [Display(Name ="標題")]
        [Required]
        public string fTitle { get; set; }

        [StringLength(50)]
        [Display(Name ="圖示")]
        public string fImage { get; set; }

        [Column(TypeName = "date")]
        [Display(Name ="結案日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime? fDate { get; set; }
    }
}
