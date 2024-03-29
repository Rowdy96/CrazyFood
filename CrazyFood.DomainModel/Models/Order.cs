﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Order
    {
        #region Public Propertry
        public int Id { get; set; }
        public bool IsOderPreparing { get; set; }
        public bool IsOnTheWay { get; set; }
        public bool IsOrderDelivered { get; set; }

        #region Navigation Propertry
        public string UserId { get; set; }
        public Users User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        #endregion
        #endregion
    }
}
