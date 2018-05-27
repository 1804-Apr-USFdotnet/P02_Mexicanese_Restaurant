using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class MenuItem
    {
        public int itemID;

        [Required]
        [StringLength(255)]
        public string itemName { get; set; }

        [Required]
        [StringLength(1024)]

        public string itemDescription { get; set; }

        [Required]
        public decimal itemPrice { get; set; }

        [Required]
        public int Stock { get; set; }

        //May need to add ICollection<OrderItemServiceModel> later to satisfy mapping
        //public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}