using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      var customer = new Customer(
          "aristoteles",
          "Coutinho",
          "123",
          "mail@mail.com",
          "86999999999",
          "Rua dos devs 8471"
        );
    }
  }
}
