using System;

namespace Repository.Models.Dtos
{
    public class CouponDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Discount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid IdProductDetail { get; set; }
        public string ProductName { get; set; }
    }
}
