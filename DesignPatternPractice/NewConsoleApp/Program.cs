
using System;
using NewConsoleApp.Patterns;

namespace NewConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var cor = new ChainOfResponsibilityService();
            cor.Execute();
		}
	}
}
