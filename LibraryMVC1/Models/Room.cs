namespace LibraryMVC1.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public ICollection<Resident> Residents { get; set; }
    }

}
