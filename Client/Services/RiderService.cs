using System.Text;
using System.Text.Json;
using FormulaOne.Shared.Models;

namespace FormulaOne.Client.Services;

public class RiderService : IRiderService
{

    private readonly HttpClient _httpClient;

    public RiderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Rider?> AddRider(Rider rider)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(rider), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/riders", itemJson);

            if(response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStreamAsync();

                var AddedRider = await JsonSerializer.DeserializeAsync<Rider>(responseBody, new JsonSerializerOptions{
                    PropertyNameCaseInsensitive = true
                });

                return AddedRider;

            }

            return null;

        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw ex;
        }
    }

    public async Task<IEnumerable<Rider>?> All()
    {
        try
        {
            var apiResponse = await _httpClient.GetStreamAsync("api/riders");

            var riders = await JsonSerializer.DeserializeAsync<IEnumerable<Rider>>(apiResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return riders;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw ex;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/riders/{id}");

            return response.IsSuccessStatusCode;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw ex;
        }
    }

    public async Task<Rider?> GetDriver(int id)
    {
        try
        {
            var response = await _httpClient.GetStreamAsync($"api/riders/{id}");

            var rider = await JsonSerializer.DeserializeAsync<Rider>(response, new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true
            });

            return rider;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw ex;
        }
    }

    public Task<Rider?> GetRider(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Rider rider)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(rider), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/riders", itemJson);

            return response.IsSuccessStatusCode;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw ex;
        }
    }
}