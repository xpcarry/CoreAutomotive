using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoreAutomotive.Models
{
    public class Opinia
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name="Nazwa użytkownika")]
        [Required(ErrorMessage ="Wprowadz nazwe uzytkownika")]
        public string NazwaUzytkownika { get; set; }

        [Display(Name ="E-mail")]
        [Required(ErrorMessage ="Wprowadz adres e-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Bledny format adresu e-mail")]
        public string Email { get; set; }

        [Display(Name = "Wiadomość")]
        [Required(ErrorMessage ="Wiadomosc jest wymagana")]
        [StringLength(5000, ErrorMessage = "Wiadomosc jest zbyt dluga")]
        public string Wiadomosc { get; set; }

        [Display(Name = "Oczekuje odpowiedzi")]
        public bool OczekujeOdpowiedzi { get; set; }

    }
}
