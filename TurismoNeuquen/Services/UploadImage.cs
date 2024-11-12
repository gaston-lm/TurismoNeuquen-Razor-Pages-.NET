using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using EjemploComponentes.Services;
using TurismoNeuqen.Services;

namespace EjemploComponentes.Services
{
    public class UploadImage : IUploadImage
    {
        private readonly HttpClient _httpClient;

        public UploadImage(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File cannot be null or empty", nameof(file));
            }

            using var fileStream = file.OpenReadStream();
            var content = new MultipartFormDataContent();

            // Add the file content to the form
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            content.Add(fileContent, "file", file.FileName);

            // Add the API key as a form parameter
            var apiKey = "5b4793ea0776995e37d2bffa2fc2a608"; // Replace with your actual API key
            content.Add(new StringContent(apiKey), "api_key");

            // ImgHippo API endpoint
            var apiUrl = "https://api.imghippo.com/v1/upload";

            // Send the POST request with the file and API key in the form data
            var response = await _httpClient.PostAsync(apiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to upload image: {response.ReasonPhrase}");
            }

            // Read the response content
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine("API Response: " + jsonResponse); // Log the full response

            // Safely parse the response and extract the URL
            try
            {
                using var jsonDoc = JsonDocument.Parse(jsonResponse);
                if (jsonDoc.RootElement.TryGetProperty("data", out var dataElement) &&
                    dataElement.TryGetProperty("url", out var urlElement))
                {
                    var url = urlElement.GetString();
                    return url ?? throw new Exception("URL not found in the response");
                }
                else
                {
                    throw new Exception("The expected 'data' or 'url' property was not found in the response");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error parsing the response: {ex.Message}", ex);
            }
        }
    }
}