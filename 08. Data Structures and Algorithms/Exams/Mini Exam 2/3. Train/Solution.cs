﻿using System;
using Wintellect.PowerCollections;

namespace Train
{
	class Program
	{
		static void Main(string[] args)
		{
			var strs = Console.ReadLine().Split(' ');
			int passengerCount = int.Parse(strs[0]);
			int trainCapacity = int.Parse(strs[1]);
			int stopsCount = int.Parse(strs[2]);

			var passengers = new Tuple<int, int>[passengerCount];

			for (int i = 0; i < passengerCount; i++)
			{
				strs = Console.ReadLine().Split(' ');
				passengers[i] = new Tuple<int, int>
				(
					int.Parse(strs[0]),
					int.Parse(strs[1])
				);
			}

			Array.Sort(passengers);

			int count = 0;
			var selectedPassengers = new OrderedBag<int>();
			foreach (var passenger in passengers)
			{
				while (selectedPassengers.Count > 0 &&
					selectedPassengers.GetFirst() <= passenger.Item1)
				{
					count++;
					selectedPassengers.RemoveFirst();
				}

				selectedPassengers.Add(passenger.Item2);
				if (selectedPassengers.Count > trainCapacity)
				{
					selectedPassengers.RemoveLast();
				}
			}

			count += selectedPassengers.Count;
			Console.WriteLine(count);
		}
	}
}
