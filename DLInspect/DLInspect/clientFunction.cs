using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
public class ClassificationResult
{
    public int class_id { get; set; }
    public string class_name { get; set; }
    public double confidence { get; set; }
}


public class ImageClassifierClient
{
    private readonly HttpClient _httpClient;

    public ImageClassifierClient(string baseUrl)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(baseUrl);
    }

    public async Task<ClassificationResult> ClassifyImageAsync(string imagePath)
    {
        if (!File.Exists(imagePath))
            throw new FileNotFoundException("Image file not found", imagePath);

        MultipartFormDataContent form = null;
        FileStream fileStream = null;
        HttpResponseMessage response = null;

        try
        {
            form = new MultipartFormDataContent();
            fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);

            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            form.Add(fileContent, "file", Path.GetFileName(imagePath));

            response = _httpClient.PostAsync("/classify", form).Result;
            response.EnsureSuccessStatusCode();

            string json =  response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ClassificationResult>(json);
        }
        finally
        {
            if (response != null) response.Dispose();
            if (form != null) form.Dispose();
            if (fileStream != null) fileStream.Dispose();
        }
    }
}
