using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace BitReserveAPI
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			getToken ("Test Token");
		}

		public static void getToken(string tokenDescription)  
		{
			using (var client = new WebClient())
			{
				var values = new Dictionary<String,object>
				{
					{ "description", tokenDescription }
				};

				string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("malina@bitreserve.org" + ":" + "Hi5doros"));

				client.Headers[HttpRequestHeader.ContentType] = "application/json";
				client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);

				string url = "https://api-sandbox.bitreserve.org/v0/me/tokens";
				string data = new JavaScriptSerializer().Serialize(values);
				string result = client.UploadString(url, "POST", data);

				Console.WriteLine(result);
			}
		}
	}
}
