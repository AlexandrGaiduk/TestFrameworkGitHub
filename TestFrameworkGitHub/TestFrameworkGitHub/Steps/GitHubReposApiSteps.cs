using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TestFrameworkGitHub.Models;
using TestFrameworkGitHub.Services;

namespace TestFrameworkGitHub.Steps
{
    [Binding]
    public class GitHubReposApiSteps
    {
        private GitHubReposApi _gitHubApi = new GitHubReposApi();
        private RepositoryModel[] _repositories;
        private RepositoryModel _repositoryCreationModel;
        private RepositoryCreationModel _repositoryData;

        [Given(@"I have data prepared for repository with (.*)")]
        public void GivenIHaveDataPreparedForRepositoryCreation(string name)
        {
            _repositoryData = FormRepositoryCreationModel(name);
        }

        [When(@"I delete (.*) repository for (.*) owner")]
        public void WhenIDeleteRepository(string repoName, string ownerName)
        {
            _gitHubApi.DeleteRepository(repoName: repoName, ownerName: ownerName);
        }

        [When(@"I create new repository")]
        public void WhenICreateNewRepository()
        {
            _repositoryCreationModel = _gitHubApi.CreateRepository(_repositoryData);
        }

        [When(@"I make get request to git repos api")]
        public void WhenIMakeGetRequestToGitReposApi()
        {
            _repositories = _gitHubApi.GetListOfRepositoriesForAuthenticatedUser();
        }

        [Then(@"(.*) repository is deleted")]
        public void ThenRepositoryIsDeleted(string repoName)
        {
            var actualRepositories = _gitHubApi.GetListOfRepositoriesForAuthenticatedUser();
            actualRepositories.Select(x => x.Name).Should().NotContain(repoName);
        }

        [Then(@"List of repositories with count (.*) should be returned")]
        public void ThenListOfRepositoriesWithCountShouldBeReturned(int numberOfRepos)
        {
            _repositories
                .Length
                .Should()
                .Be(numberOfRepos);
        }

        [Then(@"List of repositories should contain all repos names")]
        public void ThenListOfRepositoriesShouldContainAllReposNames(Table reposNames)
        {
            int index = reposNames.Header.Select((header, headerIndex) => { header.Equals("reposNames"); return headerIndex; }).FirstOrDefault();
            List<string> expected = reposNames.TableColumnWithIndexToList(index);

            _repositories
                .Select(x => x.Name)
                .Should()
                .BeEquivalentTo(expected);
        }

        [Then(@"Repository with (.*) name is created")]
        public void ThenRepositoryWithNameIsCreated(string repoName)
        {
            _repositoryCreationModel.Name.Should().BeEquivalentTo(repoName);
        }

        [Then(@"Repository is present in list of git repositories")]
        public void ThenRepositoryIsPresentInListOfGitRepositories()
        {
            var actualRepositories = _gitHubApi.GetListOfRepositoriesForAuthenticatedUser();
            actualRepositories.Any(repo => repo.Name.Equals(_repositoryCreationModel.Name));
        }

        private RepositoryCreationModel FormRepositoryCreationModel
            (string name, string description = null, string homepage = null, 
            bool @private = false, bool has_issues = true, bool has_projects = true, 
            bool has_wiki = true)
        {
            return new RepositoryCreationModel()
            {
                name = name,
                description = string.IsNullOrEmpty(description) ? "Created by WebClient" : description,
                homepage = string.IsNullOrEmpty(homepage) ? "https://github.com" : homepage,
                @private = @private,
                has_issues = has_issues,
                has_projects = has_projects,
                has_wiki = has_wiki
            };
        }
    }
}
