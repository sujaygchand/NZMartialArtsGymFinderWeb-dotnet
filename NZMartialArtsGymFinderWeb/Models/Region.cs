using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZMartialArtsGymFinderWeb.Models
{
	public class Region : BaseModel
	{
		public string DiallingCode { get; set; }
		public byte[] Picture { get; set; }
	}
}
