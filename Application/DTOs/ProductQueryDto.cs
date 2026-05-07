namespace AppCrud.Application.DTOs
{
    public class ProductQueryDto
    {
        public string Filter { get; set; } = "all";
        public string Query { get; set; } = "";
        public int Limit { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
