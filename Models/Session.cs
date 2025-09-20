namespace FitnessRestApi.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public string Notes { get; set; }
    }
}
