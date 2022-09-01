namespace DepartmentStore.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Rate { get; set; }
        public float TotalCost { get { return this.Rate * this.Quantity; } }
    }
}
