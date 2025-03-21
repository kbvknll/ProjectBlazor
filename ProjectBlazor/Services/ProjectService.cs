using System.Net.Http.Json;
using ProjectBlazor.Models;
using System.Threading.Tasks; 

namespace ProjectBlazor.Services
{
    public class ProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Project>>("api/projects");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении проектов: {ex.Message}");
                return new List<Project>();
            }
        }

        public async Task<Project> GetProjectAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Project>($"api/projects/{id}");
        }

        public async System.Threading.Tasks.Task CreateProjectAsync(Project project)
        {
            var response = await _httpClient.PostAsJsonAsync("api/projects", project);
            response.EnsureSuccessStatusCode();
        }

        public async System.Threading.Tasks.Task UpdateProjectAsync(int id, Project project)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/projects/{id}", project);
            response.EnsureSuccessStatusCode();
        }

        public async System.Threading.Tasks.Task DeleteProjectAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/projects/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}