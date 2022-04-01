using Consumer.Models;
using Newtonsoft.Json;

namespace Consumer.Service {
	public class PersonService
	{
		private static readonly string restUrl = "https://localhost:7103/api/Persons";
		private readonly HttpClient _client;

		public PersonService()
		{
			_client = new HttpClient();
		}

		public async Task<List<Person>> GetPersons() {
			List<Person>? listFromService = null;

			//api/Persons/id
			string useRestUrl = restUrl;

			var uri = new Uri(useRestUrl);
			try {
				var response = await _client.GetAsync(uri);
				if (response.IsSuccessStatusCode) {
					var content = await response.Content.ReadAsStringAsync();

					listFromService = JsonConvert.DeserializeObject<List<Person>>(content);

				} else {
					if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
						listFromService = new List<Person>();
					} else {
						listFromService = null;
					}
				}
			} catch (Exception e) {
				listFromService = null;
			}

			return listFromService;
		}

		public async Task<Person> GetPersonByEmail(string personEmail)
		{
			Person? person = null;
			string useRestUrl = restUrl + "/" + personEmail;

			var uri = new Uri(useRestUrl);
			try
			{
				var response = await _client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					person = JsonConvert.DeserializeObject<Person>(content);
				}
			} 
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return person;
		}
	}
}
