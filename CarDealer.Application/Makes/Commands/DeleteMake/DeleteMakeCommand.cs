using CarDealer.Application.Interfaces.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Makes.Commands.DeleteMake
{
	public class DeleteMakeCommand : ICommand
	{
		public int Id { get; }

		public DeleteMakeCommand(int id)
		{
			this.Id = id;
		}
	}
}
