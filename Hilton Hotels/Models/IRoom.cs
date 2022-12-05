namespace Hilton_Hotels.Models
{
    public interface IRoom
    {
        int ID { get; set; } 

        string Type { get; set; }

        double Price { get; set; }
    }
}
