using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entites
{
    public class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
