using System;
using System.Net.Http;
using System.Threading.Tasks;

public class AddressApiClient
{
    public async Task DeleteAddressAsync(int addressId)
    {
        HttpClient client = new HttpClient();
        string url = "https://localhost:44351/odata/AddressesApi(" + addressId + ")";

        HttpResponseMessage response = await client.DeleteAsync(url);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Address deleted successfully.");
        }
        else
        {
            Console.WriteLine("Error deleting address. Status code: " + response.StatusCode);
        }
    }
}