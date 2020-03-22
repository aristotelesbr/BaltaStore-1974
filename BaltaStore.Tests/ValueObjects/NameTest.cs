using BaltaStore.Domain.StoreContext.ValeObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
  [TestClass]
  public class NameTest
  {
    [TestMethod]
    public void ShouldReturnNotificationWhenNameIsNotValid()
    {
      var name = new Name("", "Coutinho");
      Assert.AreEqual(false, name.IsValid);
      Assert.AreEqual(1, name.Notifications.Count);
    }
  }
}
