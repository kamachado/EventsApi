
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEvents.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }    

        public int TicketQuantity { get; set; }

        public double TicketPrice { get; set; }

        public int IdEventPlace { get; set; }

        [ForeignKey("IdEventPlace")]
        public EventPlace? EventPlace { get; set; }


    }
}
