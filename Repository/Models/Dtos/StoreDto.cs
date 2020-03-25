using System;

namespace Repository.Models.Dtos
{
    public class StoreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FiscalName { get; set; }
        public string Address { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string RFC { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid IdOwner { get; set; }
        public string Owner { get; set; }
        public string SubCategoryName { get; set; }
    }
}
