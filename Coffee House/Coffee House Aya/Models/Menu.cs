namespace Coffee_House_Aya.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public int CoffeeId { get; set; }
        public int SweetId { get; set; }
        public Sweet? Sweet { get; set; }
        public Coffee? Coffee { get; set; }


    }
}
