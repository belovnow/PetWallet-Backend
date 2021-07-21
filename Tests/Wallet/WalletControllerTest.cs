/*
using AccountantAppWebAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Wallet
{
	[TestClass]
	public class WalletControllerTest
	{
		[TestMethod]
		public void SaveWallet_ValidWallet_Ok()
		{
			var wallet = new Model.Wallet
			{
				Id = 1,
				Name = "Test",
				Amount = 100
			};

			var repoMock = new Mock<IGenericRepository<Model.Wallet>>();
			repoMock.Setup(repo => repo.GetById(0))
				.Returns(wallet)
				.Verifiable();

			var contextMock = new Mock<IModelContext>();
			contextMock.Setup(c => c.WalletRepository).Returns(repoMock.Object);

			var controller = new WalletController(contextMock.Object);

			var actual = controller.GetWallets();
		}
	}
}
*/
