Feature: GitHubReposAPI
	As PO 
	I want to have Repository API 
	To allow users to have access to their repositories from other applications. 


Scenario: 01 List of repositories should be returned when user makes get request to git repos api
	When I make get request to git repos api  
	Then List of repositories with count 2 should be returned
	And List of repositories should contain all repos names
	    | reposNames  |
	    | Hello-World |
	    | NewRepo     |

Scenario: 02 Repository should be created after post request prformed
    Given I have data prepared for repository with <repoName>
	When I create new repository
	Then Repository with <repoName> name is created
	And Repository is present in list of git repositories
	Examples: 
| repoName |
| NewRepo1 |

Scenario: 03 Repository should be deleted after delete request performed
When I delete <repoName> repository for <ownerName> owner
Then <repoName> repository is deleted
	Examples: 
| repoName | ownerName          |
| NewRepo1 | AlexandrGaidukTest |