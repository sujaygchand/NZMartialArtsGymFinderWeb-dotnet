using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZMartialArtsGymFinderWeb.Utilities
{
	public class StaticDetails
	{
		public static string APIBaseUrl = "https://n8w073lxid.execute-api.ap-southeast-2.amazonaws.com/";
		public static string RegionAPIPath = APIBaseUrl + "api/Region/";
		public static string GymAPIPath = APIBaseUrl + "api/Gym/";
		public static string MartialArtAPIPath = APIBaseUrl + "api/MartialArt/";
		public static string UserAPIPath = APIBaseUrl + "api/user/";

		public static string Alert = "alert";
	}
}
