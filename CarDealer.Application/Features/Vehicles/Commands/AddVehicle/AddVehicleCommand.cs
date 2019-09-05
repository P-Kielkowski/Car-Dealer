using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Features.Vehicles.Commands.AddVehicle
{
	public class AddVehicleCommand : IRequest<int>
	{
		public int Id { get; }
		public int ModelId { get; }
		public string ContactName { get; }
		public string ContactPhone { get; }
		public DateTime LastUpdate { get; }

		public AddVehicleCommand(int Id, int ModelId, string ContactName,
			string ContactPhone, DateTime LastUpdate)
		{
			this.Id = Id;
			this.ModelId = ModelId;
			this.ContactName = ContactName;
			this.ContactPhone = ContactPhone;
			this.LastUpdate = LastUpdate;
		}
	}
}
