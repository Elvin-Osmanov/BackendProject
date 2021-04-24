using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class Setting:BaseEntity
    {

        [StringLength(maximumLength: 250, ErrorMessage = "Lenght should be no more than 250 characters!!!")]
        public string HeaderLogo { get; set; }

        [NotMapped]
        public IFormFile Header { get; set; }

       
        [StringLength(maximumLength: 250, ErrorMessage = "Lenght should be no more than 250 characters!!!")]
        public string FooterLogo { get; set; }

        [NotMapped]
        public IFormFile Footer { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "Lenght should be no more than 200 characters!!!")]
        public string FooterDesc { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string VideoRedirectUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string FacebookUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string TwitterUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string VimeoUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string PinterestUrl { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string ServicePhone { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string SupportPhone { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string Webname { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string SupportEmail { get; set; }


        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string AboutTitle { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string AboutDesc { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 150, ErrorMessage = "Lenght should be no more than 150 characters!!!")]
        public string AboutPhoto { get; set; }

        [NotMapped]
        public IFormFile AboutFile { get; set; }

        [NotMapped]
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}
