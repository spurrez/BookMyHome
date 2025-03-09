﻿using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Domain.Entities
{
	public class Host : User
	{

		public virtual ICollection<Accommodation>? AccommodationsOwned { get; set; }

	}
}
