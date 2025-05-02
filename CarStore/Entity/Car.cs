using System.ComponentModel.DataAnnotations;

namespace CarStore.Entity
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }   
        public decimal Price { get; set; }
    }
}
