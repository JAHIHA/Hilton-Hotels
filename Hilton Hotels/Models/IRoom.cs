namespace Hilton_Hotels.Models
{
    public interface IRoom
    {
        string ID { get; set; } 

        string Type { get; set; }

        double Price { get; set; }
    }
}
