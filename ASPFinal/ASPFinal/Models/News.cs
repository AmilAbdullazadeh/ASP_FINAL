using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPFinal.Models
{
    public class News
    {

        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "Image's name can not be more than 255 characters")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Title should be filled")]
        [StringLength(100, ErrorMessage = "Title can not be more than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content should be filled")]
        [StringLength(255, ErrorMessage = "Title can not be more than 255 characters")]
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }
    }
}