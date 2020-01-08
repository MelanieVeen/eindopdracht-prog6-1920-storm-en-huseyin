﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BeestjeOpJeFeestje.Models
{
	public class Accessories
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		public string Name { get; set; }
		[DisplayFormat(DataFormatString = "{0:n} €")]
		public double Price { get; set; }
		public string PicturePath { get; set; }

		public Accessories(string name, double price, string picturePath = "")
		{
			Name = name;
			Price = price;
			PicturePath = picturePath;
		}

		public Accessories()
		{
		}

		public List<AnimalAccessories> AnimalAccessories { get; set; }
	}
}