using CarDealer.Application.Interfaces.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Application.Makes.Commands.AddMake
{
	public class AddMakeCommand : ICommand
	{
		public string Name { get; }

		public AddMakeCommand(string name)
		{
			this.Name = name;
		}
	}
}
