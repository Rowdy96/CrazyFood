using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Order
    {
        #region Public Propertry
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public bool IsOderPreparing { get; set; }
        public bool IsOnTheWay { get; set; }
        public bool IsOrderDelivered { get; set; }

        #region Navigation Propertry
        public int UserId { get; set; }
        public Users User { get; set; }
        //public ICollection<OrderItem> OrderItems { get; set; }
        #endregion
        #endregion
    }
}
