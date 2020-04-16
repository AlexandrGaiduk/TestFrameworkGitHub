using TestFrameworkGitHub.Models;
using Newtonsoft.Json;

namespace TestFrameworkGitHub.Services
{
    public class GitHubReposApi : WebClientRequestBase
    {
        private const string BaseUrl = "https://api.github.com/";
        private static string _token = "fd8c5af175f772764ba7238007173377990a817d";

        public GitHubReposApi(): base(BaseUrl, _token){}

        public RepositoryModel[] GetListOfRepositoriesForAuthenticatedUser()
        {
            return Get<RepositoryModel[]>("user/repos");
        }

        public RepositoryModel CreateRepository(RepositoryCreationModel repoToBeCreated)
        {
            var serializedRepoToBeCreated = JsonConvert.SerializeObject(repoToBeCreated);

            return Post<RepositoryModel>("user/repos", serializedRepoToBeCreated);
        }

        public void DeleteRepository(string repoName, string ownerName)
        {
            Delete($"repos/{ownerName}/{repoName}");
        }
    }
}
