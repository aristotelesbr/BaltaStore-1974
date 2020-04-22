using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValeObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Entities
{
  [TestClass]
  public class OrderTest
  {
    private Product _mouse;
    private Product _keyboard;
    private Product _chair;
    private Product _monitor;
    private Customer _customer;
    private Order _order;

    public OrderTest()
    {
      var name = new Name("Ari", "Coutinho");
      var document = new Document("38652381062");
      var email = new Email("ari@mail.com");
      _customer = new Customer(name, document, email, "123123");
      _order = new Order(_customer);
      _mouse = new Product("Mouse gamer", "Razer", "mouse.jpg", 10M, 2);
      _keyboard = new Product("Teclado gamer", "Razer", "teclado.jpg", 10M, 2);
      _chair = new Product("Cadeira gamer", "Razer", "cadeira.jpg", 10M, 2);
      _monitor = new Product("Mouse gamer", "Razer", "monitor.jpg", 10M, 2);
    }

    // Consigo criar um novo pedido
    [TestMethod]
    public void ShouldCreateOrderWhenValid()
    {
      Assert.AreEqual(true, _order.IsValid);
    }

    // Ao criar o pedido, o status deve ser created
    [TestMethod]
    public void StatusShouldBeCreateOrderWhenCreated()
    {
      var order = new Order(_customer);
      Assert.AreEqual(EOrderStatus.Created, _order.Status);
    }

    // Ao adcionar um item, a quantidade deve mudar
    [TestMethod]
    public void ShouldReturnTwoWhenAddedTwoValidItems()
    {
      _order.AddItem(_chair, 5);
      _order.AddItem(_mouse, 5);
      Assert.AreEqual(2, _order.Items.Count);
    }

    // Ao adicionar um novo item, deve subtrari a quantidade do produto
    [TestMethod]
    public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
    {
      _order.AddItem(_mouse, 1);
      Assert.AreEqual(_mouse.QuantityOnHand, 1);
    }

    // Ao confirmar pedido, deve gerar um número
    [TestMethod]
    public void ShouldReturnANumeberWhenOrderPlaced()
    {
      _order.Place();
      Assert.AreNotEqual("", _order.Number);
    }

    // Ao pagar um pedido, o status deve se PAGO
    [TestMethod]
    public void ShouldReturnPaidWhenORderIsPaid()
    {
      _order.Pay();
      Assert.AreEqual(EOrderStatus.Paid, _order.Status);
    }

    // Dado mais 10 produtos, devem haver duas entregas
    [TestMethod]
    public void ShouldTwoShippingsWhenPurchasedTenProducts()
    {
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.Ship();

      Assert.AreEqual(2, _order.Deliveries.Count);
    }

    // Ao cancelar o pedido, o status deve ser cancelado
    [TestMethod]
    public void StatusShouldBeCanceledWhenOrderCanceled()
    {
      _order.Cancel();
      Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
    }

    // Ao cancelar o pedido, deve cancelar as entregas
    [TestMethod]
    public void ShouldCancelShippingsWhenOrder()
    {
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.AddItem(_mouse, 1);
      _order.Cancel();

      foreach (var delivery in _order.Deliveries)
      {
        Assert.AreEqual(EDeliveryStatus.Canceled, delivery.Status);
      }
    }
  }
}
