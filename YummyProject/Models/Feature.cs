using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }

        [Required(ErrorMessage ="Resim linki boş bırakılamaz.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [MinLength(5,ErrorMessage ="Başlık en az 5 karakter olmalıdır.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Video linki boş bırakılamaz.")]
        public string VideoUrl { get; set; }
    }
}