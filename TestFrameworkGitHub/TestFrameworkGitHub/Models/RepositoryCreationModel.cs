
namespace TestFrameworkGitHub
{
    public class RepositoryCreationModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
        public bool @private { get; set; }
        public bool has_issues { get; set; }
        public bool has_projects { get; set; }
        public bool has_wiki { get; set; }
    }
}
