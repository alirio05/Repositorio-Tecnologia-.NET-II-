using Business.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace Business.Domain.Models
{
    public class Customer :BaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        

        [ForeignKey("CustomerType")]
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
