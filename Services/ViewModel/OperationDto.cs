using System;
using Microsoft.OpenApi.Models;

namespace AccountantAppWebAPI.ViewModel
{
	public class OperationDto
	{
		public int Id { get; set; }

		public OperationType Type { get; set; }

		public double Amount { get; set; }

		public DateTime Executed { get; set; }

		public string Wallet { get; set; }

		public string Account { get; set; }
	}
}
