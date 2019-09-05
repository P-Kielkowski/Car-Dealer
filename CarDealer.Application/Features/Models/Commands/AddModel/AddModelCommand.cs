using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Models.Commands.AddModel
{
	public class AddModelCommand : IRequest<int>
	{
		public int Id { get;  }
		public string Name { get; }
		public int MakeId { get; }

		public AddModelCommand( int id, string name, int makeId )
		{
			this.Id = id;
			this.Name = name;
			this.MakeId = makeId;
		}

	}
}
