using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuTakip.ENTITIES
{
    public class Appointment : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        public string UserSurname { get; set; }
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        public string PolicyNumber { get; set; }
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
