using System;

namespace Repository.Models.Dtos
{
    public class StoreCategoryDetailDto
    {
        public Guid Id { get; set; }
        public Guid IdStore { get; set; }
        public Guid IdCategoryStore { get; set; }
        public string Store { get; set; }
        public string Category { get; set; }
    }
}
