namespace NetExam.Dao.Dto
{
    using NetExam.Abstractions;

    public class Office : IOffice
    {
        public string LocationName { get; set; }
        public string Name { get; set; }
    }
}
