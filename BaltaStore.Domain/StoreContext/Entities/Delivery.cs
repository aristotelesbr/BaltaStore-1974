using System;
using BaltaStore.Domain.StoreContext.Enums;

namespace BaltaStore.Domain.StoreContext.Entities
{
  public class Delivery
  {
    public Delivery(DateTime estimatedDeliveryDate)
    {
      CreateDate = DateTime.Now;
      EstimatedDeliveryDate = estimatedDeliveryDate;
      Status = Enums.EDeliveryStatus.Waiting;
    }
    public DateTime CreateDate { get; private set; }
    public DateTime EstimatedDeliveryDate { get; private set; }
    public EDeliveryStatus Status { get; private set; }
  }
}
