namespace LibraryMVC1.Models
{
    public class Resident
    {
        public int Id { get; set; }  
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }

}
