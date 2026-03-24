using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmlakSitesi.Models;

    public class Ilan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Başlık alanı zorunludur")]
        [Display(Name ="Başlık")]
        public string Baslik {get;set;}

        [Display(Name ="Açıklama")]
        [Required(ErrorMessage ="Açıklama alanı zorunludur")]
        public string Aciklama { get; set; }

        [Display(Name ="Tür")]
        [Required(ErrorMessage ="Tür alanı zorunludur")]
        public string Tur { get; set; }

        [Display(Name ="Fiyat")]
        [Required(ErrorMessage ="Fiyat alanı zorunludur")]
        [Precision(18,2)]
        public decimal Fiyat { get; set; }

        [Display(Name ="Fotoğraf")]
        public string? Foto { get; set; }
    }
