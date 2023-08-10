namespace Records.Data.Dtos
{
    public  class CatDto
    {
       public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime? CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }

    }
}
