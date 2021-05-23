using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PostDetail
    {
        public int PostId { get; set; }
        public Nullable<int> PostWeight { get; set; }
        [Display(Name = "Post Name")]
        public string PostName { get; set; }
        public Nullable<int> catId { get; set; }
        [NotMapped]
        [Display(Name = "Categoty Name")]
        public string catName { get; set; }
        public DateTime fromdt { get; set; }
        public List<PostDetail> usersinfo { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
    }
}