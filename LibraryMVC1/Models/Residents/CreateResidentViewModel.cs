using System.ComponentModel.DataAnnotations;

namespace LibraryMVC1.Models.Residents
{
    public class CreateResidentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето 'Име' е задължително.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Полето 'Имейл' е задължително.")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето 'Стая' е задължително.")]
        
        public int RoomId { get; set; }
        
       
    }
}
