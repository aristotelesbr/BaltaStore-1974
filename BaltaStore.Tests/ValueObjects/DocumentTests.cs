using BaltaStore.Domain.StoreContext.ValeObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
  [TestClass]
  public class DocumentTests
  {
    private Document validDocument;
    private Document invalidDocument;
    public DocumentTests()
    {
      validDocument = new Document("99737827040");
      invalidDocument = new Document("12345678901");
    }

    [TestMethod]
    public void ShouldReturnNotificationWhenDocuemntIsNotValid()
    {
      Assert.AreEqual(false, invalidDocument.IsValid);
      Assert.AreEqual(1, invalidDocument.Notifications.Count);
    }

    [TestMethod]
    public void ShouldReturnNotificationWhenDocuemntIsValid()
    {
      Assert.AreEqual(true, validDocument.IsValid);
      Assert.AreEqual(0, validDocument.Notifications.Count);
    }
  }
}
