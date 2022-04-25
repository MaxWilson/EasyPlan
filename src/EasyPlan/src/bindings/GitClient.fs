// ts2fable 0.7.1
module rec GitClient
open System
open Fable.Core
open Fable.Core.JS

type IVssRestClientOptions = Context.IVssRestClientOptions
type RestClientBase = RestClientBase.RestClientBase

type [<AllowNullLiteral>] IExports =
    abstract GitRestClient: GitRestClientStatic

type [<AllowNullLiteral>] GitRestClient =
    inherit RestClientBase
    /// <summary>Create an annotated tag.</summary>
    /// <param name="tagObject">- Object containing details of tag to be created.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- ID or name of the repository.</param>
    abstract createAnnotatedTag: tagObject: Git.GitAnnotatedTag * project: string * repositoryId: string -> Promise<Git.GitAnnotatedTag>
    /// <summary>Get an annotated tag.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- ID or name of the repository.</param>
    /// <param name="objectId">- ObjectId (Sha1Id) of tag to get.</param>
    abstract getAnnotatedTag: project: string * repositoryId: string * objectId: string -> Promise<Git.GitAnnotatedTag>
    /// <summary>Get a single blob.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="sha1">- SHA1 hash of the file. You can get the SHA1 of a file using the "Git/Items/Get Item" endpoint.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="download">- If true, prompt for a download rather than rendering in a browser. Note: this value defaults to true if $format is zip</param>
    /// <param name="fileName">- Provide a fileName to use for a download.</param>
    /// <param name="resolveLfs">- If true, try to resolve a blob to its LFS contents, if it's an LFS pointer file. Only compatible with octet-stream Accept headers or $format types</param>
    abstract getBlob: repositoryId: string * sha1: string * ?project: string * ?download: bool * ?fileName: string * ?resolveLfs: bool -> Promise<Git.GitBlobRef>
    /// <summary>Get a single blob.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="sha1">- SHA1 hash of the file. You can get the SHA1 of a file using the "Git/Items/Get Item" endpoint.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="download">- If true, prompt for a download rather than rendering in a browser. Note: this value defaults to true if $format is zip</param>
    /// <param name="fileName">- Provide a fileName to use for a download.</param>
    /// <param name="resolveLfs">- If true, try to resolve a blob to its LFS contents, if it's an LFS pointer file. Only compatible with octet-stream Accept headers or $format types</param>
    abstract getBlobContent: repositoryId: string * sha1: string * ?project: string * ?download: bool * ?fileName: string * ?resolveLfs: bool -> Promise<ArrayBuffer>
    /// <summary>Gets one or more blobs in a zip file download.</summary>
    /// <param name="blobIds">- Blob IDs (SHA1 hashes) to be returned in the zip file.</param>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="filename">-</param>
    abstract getBlobsZip: blobIds: ResizeArray<string> * repositoryId: string * ?project: string * ?filename: string -> Promise<ArrayBuffer>
    /// <summary>Get a single blob.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="sha1">- SHA1 hash of the file. You can get the SHA1 of a file using the "Git/Items/Get Item" endpoint.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="download">- If true, prompt for a download rather than rendering in a browser. Note: this value defaults to true if $format is zip</param>
    /// <param name="fileName">- Provide a fileName to use for a download.</param>
    /// <param name="resolveLfs">- If true, try to resolve a blob to its LFS contents, if it's an LFS pointer file. Only compatible with octet-stream Accept headers or $format types</param>
    abstract getBlobZip: repositoryId: string * sha1: string * ?project: string * ?download: bool * ?fileName: string * ?resolveLfs: bool -> Promise<ArrayBuffer>
    /// <summary>Retrieve statistics about a single branch.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="name">- Name of the branch.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="baseVersionDescriptor">- Identifies the commit or branch to use as the base.</param>
    abstract getBranch: repositoryId: string * name: string * ?project: string * ?baseVersionDescriptor: Git.GitVersionDescriptor -> Promise<Git.GitBranchStats>
    /// <summary>Retrieve statistics about all branches within a repository.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="baseVersionDescriptor">- Identifies the commit or branch to use as the base.</param>
    abstract getBranches: repositoryId: string * ?project: string * ?baseVersionDescriptor: Git.GitVersionDescriptor -> Promise<ResizeArray<Git.GitBranchStats>>
    /// <param name="searchCriteria">-</param>
    /// <param name="repositoryId">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getBranchStatsBatch: searchCriteria: Git.GitQueryBranchStatsCriteria * repositoryId: string * ?project: string -> Promise<ResizeArray<Git.GitBranchStats>>
    /// <summary>Retrieve changes for a particular commit.</summary>
    /// <param name="commitId">- The id of the commit.</param>
    /// <param name="repositoryId">- The id or friendly name of the repository. To use the friendly name, projectId must also be specified.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="top">- The maximum number of changes to return.</param>
    /// <param name="skip">- The number of changes to skip.</param>
    abstract getChanges: commitId: string * repositoryId: string * ?project: string * ?top: float * ?skip: float -> Promise<Git.GitCommitChanges>
    /// <summary>Given a commitId, returns a list of commits that are in the same cherry-pick family.</summary>
    /// <param name="repositoryNameOrId">-</param>
    /// <param name="commitId">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeLinks">-</param>
    abstract getCherryPickRelationships: repositoryNameOrId: string * commitId: string * ?project: string * ?includeLinks: bool -> Promise<ResizeArray<Git.GitCommitRef>>
    /// <summary>Cherry pick a specific commit or commits that are associated to a pull request into a new branch.</summary>
    /// <param name="cherryPickToCreate">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- ID of the repository.</param>
    abstract createCherryPick: cherryPickToCreate: Git.GitAsyncRefOperationParameters * project: string * repositoryId: string -> Promise<Git.GitCherryPick>
    /// <summary>Retrieve information about a cherry pick by cherry pick Id.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="cherryPickId">- ID of the cherry pick.</param>
    /// <param name="repositoryId">- ID of the repository.</param>
    abstract getCherryPick: project: string * cherryPickId: float * repositoryId: string -> Promise<Git.GitCherryPick>
    /// <summary>Retrieve information about a cherry pick for a specific branch.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- ID of the repository.</param>
    /// <param name="refName">- The GitAsyncRefOperationParameters generatedRefName used for the cherry pick operation.</param>
    abstract getCherryPickForRefName: project: string * repositoryId: string * refName: string -> Promise<Git.GitCherryPick>
    /// <summary>Find the closest common commit (the merge base) between base and target commits, and get the diff between either the base and target commits or common and target commits.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="diffCommonCommit">- If true, diff between common and target commits. If false, diff between base and target commits.</param>
    /// <param name="top">- Maximum number of changes to return. Defaults to 100.</param>
    /// <param name="skip">- Number of changes to skip</param>
    /// <param name="baseVersionDescriptor">- Descriptor for base commit.</param>
    /// <param name="targetVersionDescriptor">- Descriptor for target commit.</param>
    abstract getCommitDiffs: repositoryId: string * ?project: string * ?diffCommonCommit: bool * ?top: float * ?skip: float * ?baseVersionDescriptor: Git.GitBaseVersionDescriptor * ?targetVersionDescriptor: Git.GitTargetVersionDescriptor -> Promise<Git.GitCommitDiffs>
    /// <summary>Retrieve a particular commit.</summary>
    /// <param name="commitId">- The id of the commit.</param>
    /// <param name="repositoryId">- The id or friendly name of the repository. To use the friendly name, projectId must also be specified.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="changeCount">- The number of changes to include in the result.</param>
    abstract getCommit: commitId: string * repositoryId: string * ?project: string * ?changeCount: float -> Promise<Git.GitCommit>
    /// <summary>Retrieve git commits for a project</summary>
    /// <param name="repositoryId">- The id or friendly name of the repository. To use the friendly name, projectId must also be specified.</param>
    /// <param name="searchCriteria">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getCommits: repositoryId: string * searchCriteria: Git.GitQueryCommitsCriteria * ?project: string -> Promise<ResizeArray<Git.GitCommitRef>>
    /// <summary>Retrieve a list of commits associated with a particular push.</summary>
    /// <param name="repositoryId">- The id or friendly name of the repository. To use the friendly name, projectId must also be specified.</param>
    /// <param name="pushId">- The id of the push.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="top">- The maximum number of commits to return ("get the top x commits").</param>
    /// <param name="skip">- The number of commits to skip.</param>
    /// <param name="includeLinks">- Set to false to avoid including REST Url links for resources. Defaults to true.</param>
    abstract getPushCommits: repositoryId: string * pushId: float * ?project: string * ?top: float * ?skip: float * ?includeLinks: bool -> Promise<ResizeArray<Git.GitCommitRef>>
    /// <summary>Retrieve git commits for a project matching the search criteria</summary>
    /// <param name="searchCriteria">- Search options</param>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="skip">- Number of commits to skip.</param>
    /// <param name="top">- Maximum number of commits to return.</param>
    /// <param name="includeStatuses">- True to include additional commit status information.</param>
    abstract getCommitsBatch: searchCriteria: Git.GitQueryCommitsCriteria * repositoryId: string * ?project: string * ?skip: float * ?top: float * ?includeStatuses: bool -> Promise<ResizeArray<Git.GitCommitRef>>
    /// <summary>Retrieve deleted git repositories.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getDeletedRepositories: project: string -> Promise<ResizeArray<Git.GitDeletedRepository>>
    /// <summary>Get the file diffs for each of the specified files</summary>
    /// <param name="fileDiffsCriteria">- List of file parameters objects</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- The name or ID of the repository</param>
    abstract getFileDiffs: fileDiffsCriteria: Git.FileDiffsCriteria * project: string * repositoryId: string -> Promise<ResizeArray<Git.FileDiff>>
    /// <summary>Retrieve all forks of a repository in the collection.</summary>
    /// <param name="repositoryNameOrId">- The name or ID of the repository.</param>
    /// <param name="collectionId">- Team project collection ID.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeLinks">- True to include links.</param>
    abstract getForks: repositoryNameOrId: string * collectionId: string * ?project: string * ?includeLinks: bool -> Promise<ResizeArray<Git.GitRepositoryRef>>
    /// <summary>Request that another repository's refs be fetched into this one. It syncs two existing forks. To create a fork, please see the \<a href="https://docs.microsoft.com/en-us/rest/api/vsts/git/repositories/create?view=azure-devops-rest-5.1"\> repositories endpoint\</a\></summary>
    /// <param name="syncParams">- Source repository and ref mapping.</param>
    /// <param name="repositoryNameOrId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeLinks">- True to include links</param>
    abstract createForkSyncRequest: syncParams: Git.GitForkSyncRequestParameters * repositoryNameOrId: string * ?project: string * ?includeLinks: bool -> Promise<Git.GitForkSyncRequest>
    /// <summary>Get a specific fork sync operation's details.</summary>
    /// <param name="repositoryNameOrId">- The name or ID of the repository.</param>
    /// <param name="forkSyncOperationId">- OperationId of the sync request.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeLinks">- True to include links.</param>
    abstract getForkSyncRequest: repositoryNameOrId: string * forkSyncOperationId: float * ?project: string * ?includeLinks: bool -> Promise<Git.GitForkSyncRequest>
    /// <summary>Retrieve all requested fork sync operations on this repository.</summary>
    /// <param name="repositoryNameOrId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeAbandoned">- True to include abandoned requests.</param>
    /// <param name="includeLinks">- True to include links.</param>
    abstract getForkSyncRequests: repositoryNameOrId: string * ?project: string * ?includeAbandoned: bool * ?includeLinks: bool -> Promise<ResizeArray<Git.GitForkSyncRequest>>
    /// <summary>Create an import request.</summary>
    /// <param name="importRequest">- The import request to create.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    abstract createImportRequest: importRequest: Git.GitImportRequest * project: string * repositoryId: string -> Promise<Git.GitImportRequest>
    /// <summary>Retrieve a particular import request.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="importRequestId">- The unique identifier for the import request.</param>
    abstract getImportRequest: project: string * repositoryId: string * importRequestId: float -> Promise<Git.GitImportRequest>
    /// <summary>Retrieve import requests for a repository.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="includeAbandoned">- True to include abandoned import requests in the results.</param>
    abstract queryImportRequests: project: string * repositoryId: string * ?includeAbandoned: bool -> Promise<ResizeArray<Git.GitImportRequest>>
    /// <summary>Retry or abandon a failed import request.</summary>
    /// <param name="importRequestToUpdate">- The updated version of the import request. Currently, the only change allowed is setting the Status to Queued or Abandoned.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="importRequestId">- The unique identifier for the import request to update.</param>
    abstract updateImportRequest: importRequestToUpdate: Git.GitImportRequest * project: string * repositoryId: string * importRequestId: float -> Promise<Git.GitImportRequest>
    /// <summary>Get Item Metadata and/or Content for a single item. The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response. Doesn't apply to zipped content, which is always returned as a download.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="path">- The item path.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="scopePath">- The path scope.  The default is null.</param>
    /// <param name="recursionLevel">- The recursion level of this request. The default is 'none', no recursion.</param>
    /// <param name="includeContentMetadata">- Set to true to include content metadata.  Default is false.</param>
    /// <param name="latestProcessedChange">- Set to true to include the latest changes.  Default is false.</param>
    /// <param name="download">- Set to true to download the response as a file.  Default is false.</param>
    /// <param name="versionDescriptor">- Version descriptor.  Default is the default branch for the repository.</param>
    /// <param name="includeContent">- Set to true to include item content when requesting json.  Default is false.</param>
    /// <param name="resolveLfs">- Set to true to resolve Git LFS pointer files to return actual content from Git LFS.  Default is false.</param>
    abstract getItem: repositoryId: string * path: string * ?project: string * ?scopePath: string * ?recursionLevel: Git.VersionControlRecursionType * ?includeContentMetadata: bool * ?latestProcessedChange: bool * ?download: bool * ?versionDescriptor: Git.GitVersionDescriptor * ?includeContent: bool * ?resolveLfs: bool -> Promise<Git.GitItem>
    /// <summary>Get Item Metadata and/or Content for a single item. The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response. Doesn't apply to zipped content, which is always returned as a download.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="path">- The item path.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="scopePath">- The path scope.  The default is null.</param>
    /// <param name="recursionLevel">- The recursion level of this request. The default is 'none', no recursion.</param>
    /// <param name="includeContentMetadata">- Set to true to include content metadata.  Default is false.</param>
    /// <param name="latestProcessedChange">- Set to true to include the latest changes.  Default is false.</param>
    /// <param name="download">- Set to true to download the response as a file.  Default is false.</param>
    /// <param name="versionDescriptor">- Version descriptor.  Default is the default branch for the repository.</param>
    /// <param name="includeContent">- Set to true to include item content when requesting json.  Default is false.</param>
    /// <param name="resolveLfs">- Set to true to resolve Git LFS pointer files to return actual content from Git LFS.  Default is false.</param>
    abstract getItemContent: repositoryId: string * path: string * ?project: string * ?scopePath: string * ?recursionLevel: Git.VersionControlRecursionType * ?includeContentMetadata: bool * ?latestProcessedChange: bool * ?download: bool * ?versionDescriptor: Git.GitVersionDescriptor * ?includeContent: bool * ?resolveLfs: bool -> Promise<ArrayBuffer>
    /// <summary>Get Item Metadata and/or Content for a collection of items. The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response. Doesn't apply to zipped content which is always returned as a download.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="scopePath">- The path scope.  The default is null.</param>
    /// <param name="recursionLevel">- The recursion level of this request. The default is 'none', no recursion.</param>
    /// <param name="includeContentMetadata">- Set to true to include content metadata.  Default is false.</param>
    /// <param name="latestProcessedChange">- Set to true to include the latest changes.  Default is false.</param>
    /// <param name="download">- Set to true to download the response as a file.  Default is false.</param>
    /// <param name="includeLinks">- Set to true to include links to items.  Default is false.</param>
    /// <param name="versionDescriptor">- Version descriptor.  Default is the default branch for the repository.</param>
    abstract getItems: repositoryId: string * ?project: string * ?scopePath: string * ?recursionLevel: Git.VersionControlRecursionType * ?includeContentMetadata: bool * ?latestProcessedChange: bool * ?download: bool * ?includeLinks: bool * ?versionDescriptor: Git.GitVersionDescriptor -> Promise<ResizeArray<Git.GitItem>>
    /// <summary>Get Item Metadata and/or Content for a single item. The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response. Doesn't apply to zipped content, which is always returned as a download.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="path">- The item path.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="scopePath">- The path scope.  The default is null.</param>
    /// <param name="recursionLevel">- The recursion level of this request. The default is 'none', no recursion.</param>
    /// <param name="includeContentMetadata">- Set to true to include content metadata.  Default is false.</param>
    /// <param name="latestProcessedChange">- Set to true to include the latest changes.  Default is false.</param>
    /// <param name="download">- Set to true to download the response as a file.  Default is false.</param>
    /// <param name="versionDescriptor">- Version descriptor.  Default is the default branch for the repository.</param>
    /// <param name="includeContent">- Set to true to include item content when requesting json.  Default is false.</param>
    /// <param name="resolveLfs">- Set to true to resolve Git LFS pointer files to return actual content from Git LFS.  Default is false.</param>
    abstract getItemText: repositoryId: string * path: string * ?project: string * ?scopePath: string * ?recursionLevel: Git.VersionControlRecursionType * ?includeContentMetadata: bool * ?latestProcessedChange: bool * ?download: bool * ?versionDescriptor: Git.GitVersionDescriptor * ?includeContent: bool * ?resolveLfs: bool -> Promise<string>
    /// <summary>Get Item Metadata and/or Content for a single item. The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response. Doesn't apply to zipped content, which is always returned as a download.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="path">- The item path.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="scopePath">- The path scope.  The default is null.</param>
    /// <param name="recursionLevel">- The recursion level of this request. The default is 'none', no recursion.</param>
    /// <param name="includeContentMetadata">- Set to true to include content metadata.  Default is false.</param>
    /// <param name="latestProcessedChange">- Set to true to include the latest changes.  Default is false.</param>
    /// <param name="download">- Set to true to download the response as a file.  Default is false.</param>
    /// <param name="versionDescriptor">- Version descriptor.  Default is the default branch for the repository.</param>
    /// <param name="includeContent">- Set to true to include item content when requesting json.  Default is false.</param>
    /// <param name="resolveLfs">- Set to true to resolve Git LFS pointer files to return actual content from Git LFS.  Default is false.</param>
    abstract getItemZip: repositoryId: string * path: string * ?project: string * ?scopePath: string * ?recursionLevel: Git.VersionControlRecursionType * ?includeContentMetadata: bool * ?latestProcessedChange: bool * ?download: bool * ?versionDescriptor: Git.GitVersionDescriptor * ?includeContent: bool * ?resolveLfs: bool -> Promise<ArrayBuffer>
    /// <summary>Post for retrieving a creating a batch out of a set of items in a repo / project given a list of paths or a long path</summary>
    /// <param name="requestData">- Request data attributes: ItemDescriptors, IncludeContentMetadata, LatestProcessedChange, IncludeLinks. ItemDescriptors: Collection of items to fetch, including path, version, and recursion level. IncludeContentMetadata: Whether to include metadata for all items LatestProcessedChange: Whether to include shallow ref to commit that last changed each item. IncludeLinks: Whether to include the _links field on the shallow references.</param>
    /// <param name="repositoryId">- The name or ID of the repository</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getItemsBatch: requestData: Git.GitItemRequestData * repositoryId: string * ?project: string -> Promise<ResizeArray<ResizeArray<Git.GitItem>>>
    /// <summary>Find the merge bases of two commits, optionally across forks. If otherRepositoryId is not specified, the merge bases will only be calculated within the context of the local repositoryNameOrId.</summary>
    /// <param name="repositoryNameOrId">- ID or name of the local repository.</param>
    /// <param name="commitId">- First commit, usually the tip of the target branch of the potential merge.</param>
    /// <param name="otherCommitId">- Other commit, usually the tip of the source branch of the potential merge.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="otherCollectionId">- The collection ID where otherCommitId lives.</param>
    /// <param name="otherRepositoryId">- The repository ID where otherCommitId lives.</param>
    abstract getMergeBases: repositoryNameOrId: string * commitId: string * otherCommitId: string * ?project: string * ?otherCollectionId: string * ?otherRepositoryId: string -> Promise<ResizeArray<Git.GitCommitRef>>
    /// <summary>Request a git merge operation. Currently we support merging only 2 commits.</summary>
    /// <param name="mergeParameters">- Parents commitIds and merge commit messsage.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryNameOrId">- The name or ID of the repository.</param>
    /// <param name="includeLinks">- True to include links</param>
    abstract createMergeRequest: mergeParameters: Git.GitMergeParameters * project: string * repositoryNameOrId: string * ?includeLinks: bool -> Promise<Git.GitMerge>
    /// <summary>Get a specific merge operation's details.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryNameOrId">- The name or ID of the repository.</param>
    /// <param name="mergeOperationId">- OperationId of the merge request.</param>
    /// <param name="includeLinks">- True to include links</param>
    abstract getMergeRequest: project: string * repositoryNameOrId: string * mergeOperationId: float * ?includeLinks: bool -> Promise<Git.GitMerge>
    /// <summary>Attach a new file to a pull request.</summary>
    /// <param name="content">- Content to upload</param>
    /// <param name="fileName">- The name of the file.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createAttachment: content: obj option * fileName: string * repositoryId: string * pullRequestId: float * ?project: string -> Promise<Git.Attachment>
    /// <summary>Delete a pull request attachment.</summary>
    /// <param name="fileName">- The name of the attachment to delete.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract deleteAttachment: fileName: string * repositoryId: string * pullRequestId: float * ?project: string -> Promise<unit>
    /// <summary>Get the file content of a pull request attachment.</summary>
    /// <param name="fileName">- The name of the attachment.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getAttachmentContent: fileName: string * repositoryId: string * pullRequestId: float * ?project: string -> Promise<ArrayBuffer>
    /// <summary>Get a list of files attached to a given pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getAttachments: repositoryId: string * pullRequestId: float * ?project: string -> Promise<ResizeArray<Git.Attachment>>
    /// <summary>Get the file content of a pull request attachment.</summary>
    /// <param name="fileName">- The name of the attachment.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getAttachmentZip: fileName: string * repositoryId: string * pullRequestId: float * ?project: string -> Promise<ArrayBuffer>
    /// <summary>Add a like on a comment.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="threadId">- The ID of the thread that contains the comment.</param>
    /// <param name="commentId">- The ID of the comment.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createLike: repositoryId: string * pullRequestId: float * threadId: float * commentId: float * ?project: string -> Promise<unit>
    /// <summary>Delete a like on a comment.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="threadId">- The ID of the thread that contains the comment.</param>
    /// <param name="commentId">- The ID of the comment.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract deleteLike: repositoryId: string * pullRequestId: float * threadId: float * commentId: float * ?project: string -> Promise<unit>
    /// <summary>Get likes for a comment.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="threadId">- The ID of the thread that contains the comment.</param>
    /// <param name="commentId">- The ID of the comment.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getLikes: repositoryId: string * pullRequestId: float * threadId: float * commentId: float * ?project: string -> Promise<ResizeArray<WebApi.IdentityRef>>
    /// <summary>Get the commits for the specified iteration of a pull request.</summary>
    /// <param name="repositoryId">- ID or name of the repository.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="iterationId">- ID of the iteration from which to get the commits.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="top">- Maximum number of commits to return. The maximum number of commits that can be returned per batch is 500.</param>
    /// <param name="skip">- Number of commits to skip.</param>
    abstract getPullRequestIterationCommits: repositoryId: string * pullRequestId: float * iterationId: float * ?project: string * ?top: float * ?skip: float -> Promise<ResizeArray<Git.GitCommitRef>>
    /// <summary>Get the commits for the specified pull request.</summary>
    /// <param name="repositoryId">- ID or name of the repository.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestCommits: repositoryId: string * pullRequestId: float * ?project: string -> Promise<ResizeArray<Git.GitCommitRef>>
    /// <summary>Retrieve one conflict for a pull request by ID</summary>
    /// <param name="repositoryId">-</param>
    /// <param name="pullRequestId">-</param>
    /// <param name="conflictId">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestConflict: repositoryId: string * pullRequestId: float * conflictId: float * ?project: string -> Promise<Git.GitConflict>
    /// <summary>Retrieve all conflicts for a pull request</summary>
    /// <param name="repositoryId">-</param>
    /// <param name="pullRequestId">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="skip">-</param>
    /// <param name="top">-</param>
    /// <param name="includeObsolete">-</param>
    /// <param name="excludeResolved">-</param>
    /// <param name="onlyResolved">-</param>
    abstract getPullRequestConflicts: repositoryId: string * pullRequestId: float * ?project: string * ?skip: float * ?top: float * ?includeObsolete: bool * ?excludeResolved: bool * ?onlyResolved: bool -> Promise<ResizeArray<Git.GitConflict>>
    /// <summary>Update merge conflict resolution</summary>
    /// <param name="conflict">-</param>
    /// <param name="repositoryId">-</param>
    /// <param name="pullRequestId">-</param>
    /// <param name="conflictId">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updatePullRequestConflict: conflict: Git.GitConflict * repositoryId: string * pullRequestId: float * conflictId: float * ?project: string -> Promise<Git.GitConflict>
    /// <summary>Update multiple merge conflict resolutions</summary>
    /// <param name="conflictUpdates">-</param>
    /// <param name="repositoryId">-</param>
    /// <param name="pullRequestId">-</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updatePullRequestConflicts: conflictUpdates: ResizeArray<Git.GitConflict> * repositoryId: string * pullRequestId: float * ?project: string -> Promise<ResizeArray<Git.GitConflictUpdateResult>>
    /// <summary>Retrieve the changes made in a pull request between two iterations.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="iterationId">- ID of the pull request iteration. \<br /\> Iteration IDs are zero-based with zero indicating the common commit between the source and target branches. Iteration one is the head of the source branch at the time the pull request is created and subsequent iterations are created when there are pushes to the source branch.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="top">- Optional. The number of changes to retrieve.  The default value is 100 and the maximum value is 2000.</param>
    /// <param name="skip">- Optional. The number of changes to ignore.  For example, to retrieve changes 101-150, set top 50 and skip to 100.</param>
    /// <param name="compareTo">- ID of the pull request iteration to compare against.  The default value is zero which indicates the comparison is made against the common commit between the source and target branches</param>
    abstract getPullRequestIterationChanges: repositoryId: string * pullRequestId: float * iterationId: float * ?project: string * ?top: float * ?skip: float * ?compareTo: float -> Promise<Git.GitPullRequestIterationChanges>
    /// <summary>Get the specified iteration for a pull request.</summary>
    /// <param name="repositoryId">- ID or name of the repository.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="iterationId">- ID of the pull request iteration to return.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestIteration: repositoryId: string * pullRequestId: float * iterationId: float * ?project: string -> Promise<Git.GitPullRequestIteration>
    /// <summary>Get the list of iterations for the specified pull request.</summary>
    /// <param name="repositoryId">- ID or name of the repository.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeCommits">- If true, include the commits associated with each iteration in the response.</param>
    abstract getPullRequestIterations: repositoryId: string * pullRequestId: float * ?project: string * ?includeCommits: bool -> Promise<ResizeArray<Git.GitPullRequestIteration>>
    /// <summary>Create a pull request status on the iteration. This operation will have the same result as Create status on pull request with specified iteration ID in the request body.</summary>
    /// <param name="status">- Pull request status to create.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="iterationId">- ID of the pull request iteration.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createPullRequestIterationStatus: status: Git.GitPullRequestStatus * repositoryId: string * pullRequestId: float * iterationId: float * ?project: string -> Promise<Git.GitPullRequestStatus>
    /// <summary>Delete pull request iteration status.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="iterationId">- ID of the pull request iteration.</param>
    /// <param name="statusId">- ID of the pull request status.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract deletePullRequestIterationStatus: repositoryId: string * pullRequestId: float * iterationId: float * statusId: float * ?project: string -> Promise<unit>
    /// <summary>Get the specific pull request iteration status by ID. The status ID is unique within the pull request across all iterations.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="iterationId">- ID of the pull request iteration.</param>
    /// <param name="statusId">- ID of the pull request status.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestIterationStatus: repositoryId: string * pullRequestId: float * iterationId: float * statusId: float * ?project: string -> Promise<Git.GitPullRequestStatus>
    /// <summary>Get all the statuses associated with a pull request iteration.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="iterationId">- ID of the pull request iteration.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestIterationStatuses: repositoryId: string * pullRequestId: float * iterationId: float * ?project: string -> Promise<ResizeArray<Git.GitPullRequestStatus>>
    /// <summary>Update pull request iteration statuses collection. The only supported operation type is \`remove\`.</summary>
    /// <param name="patchDocument">- Operations to apply to the pull request statuses in JSON Patch format.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="iterationId">- ID of the pull request iteration.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updatePullRequestIterationStatuses: patchDocument: WebApi.JsonPatchDocument * repositoryId: string * pullRequestId: float * iterationId: float * ?project: string -> Promise<unit>
    /// <summary>Create a label for a specified pull request. The only required field is the name of the new label.</summary>
    /// <param name="label">- Label to assign to the pull request.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="projectId">- Project ID or project name.</param>
    abstract createPullRequestLabel: label: Core.WebApiCreateTagRequestData * repositoryId: string * pullRequestId: float * ?project: string * ?projectId: string -> Promise<Core.WebApiTagDefinition>
    /// <summary>Removes a label from the set of those assigned to the pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="labelIdOrName">- The name or ID of the label requested.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="projectId">- Project ID or project name.</param>
    abstract deletePullRequestLabels: repositoryId: string * pullRequestId: float * labelIdOrName: string * ?project: string * ?projectId: string -> Promise<unit>
    /// <summary>Retrieves a single label that has been assigned to a pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="labelIdOrName">- The name or ID of the label requested.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="projectId">- Project ID or project name.</param>
    abstract getPullRequestLabel: repositoryId: string * pullRequestId: float * labelIdOrName: string * ?project: string * ?projectId: string -> Promise<Core.WebApiTagDefinition>
    /// <summary>Get all the labels assigned to a pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="projectId">- Project ID or project name.</param>
    abstract getPullRequestLabels: repositoryId: string * pullRequestId: float * ?project: string * ?projectId: string -> Promise<ResizeArray<Core.WebApiTagDefinition>>
    /// <summary>Get external properties of the pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestProperties: repositoryId: string * pullRequestId: float * ?project: string -> Promise<obj option>
    /// <summary>Create or update pull request external properties. The patch operation can be \`add\`, \`replace\` or \`remove\`. For \`add\` operation, the path can be empty. If the path is empty, the value must be a list of key value pairs. For \`replace\` operation, the path cannot be empty. If the path does not exist, the property will be added to the collection. For \`remove\` operation, the path cannot be empty. If the path does not exist, no action will be performed.</summary>
    /// <param name="patchDocument">- Properties to add, replace or remove in JSON Patch format.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updatePullRequestProperties: patchDocument: WebApi.JsonPatchDocument * repositoryId: string * pullRequestId: float * ?project: string -> Promise<obj option>
    /// <summary>This API is used to find what pull requests are related to a given commit.  It can be used to either find the pull request that created a particular merge commit or it can be used to find all pull requests that have ever merged a particular commit.  The input is a list of queries which each contain a list of commits. For each commit that you search against, you will get back a dictionary of commit -\> pull requests.</summary>
    /// <param name="queries">- The list of queries to perform.</param>
    /// <param name="repositoryId">- ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestQuery: queries: Git.GitPullRequestQuery * repositoryId: string * ?project: string -> Promise<Git.GitPullRequestQuery>
    /// <summary>Add a reviewer to a pull request or cast a vote.</summary>
    /// <param name="reviewer">- Reviewer's vote.\<br /\>If the reviewer's ID is included here, it must match the reviewerID parameter.\<br /\>Reviewers can set their own vote with this method.  When adding other reviewers, vote must be set to zero.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="reviewerId">- ID of the reviewer.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createPullRequestReviewer: reviewer: Git.IdentityRefWithVote * repositoryId: string * pullRequestId: float * reviewerId: string * ?project: string -> Promise<Git.IdentityRefWithVote>
    /// <summary>Add reviewers to a pull request.</summary>
    /// <param name="reviewers">- Reviewers to add to the pull request.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createPullRequestReviewers: reviewers: ResizeArray<WebApi.IdentityRef> * repositoryId: string * pullRequestId: float * ?project: string -> Promise<ResizeArray<Git.IdentityRefWithVote>>
    /// <summary>Remove a reviewer from a pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="reviewerId">- ID of the reviewer to remove.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract deletePullRequestReviewer: repositoryId: string * pullRequestId: float * reviewerId: string * ?project: string -> Promise<unit>
    /// <summary>Retrieve information about a particular reviewer on a pull request</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="reviewerId">- ID of the reviewer.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestReviewer: repositoryId: string * pullRequestId: float * reviewerId: string * ?project: string -> Promise<Git.IdentityRefWithVote>
    /// <summary>Retrieve the reviewers for a pull request</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestReviewers: repositoryId: string * pullRequestId: float * ?project: string -> Promise<ResizeArray<Git.IdentityRefWithVote>>
    /// <summary>Edit a reviewer entry. These fields are patchable: isFlagged</summary>
    /// <param name="reviewer">- Reviewer data.\<br /\>If the reviewer's ID is included here, it must match the reviewerID parameter.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="reviewerId">- ID of the reviewer.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updatePullRequestReviewer: reviewer: Git.IdentityRefWithVote * repositoryId: string * pullRequestId: float * reviewerId: string * ?project: string -> Promise<Git.IdentityRefWithVote>
    /// <summary>Reset the votes of multiple reviewers on a pull request.  NOTE: This endpoint only supports updating votes, but does not support updating required reviewers (use policy) or display names.</summary>
    /// <param name="patchVotes">- IDs of the reviewers whose votes will be reset to zero</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updatePullRequestReviewers: patchVotes: ResizeArray<Git.IdentityRefWithVote> * repositoryId: string * pullRequestId: float * ?project: string -> Promise<unit>
    /// <summary>Retrieve a pull request.</summary>
    /// <param name="pullRequestId">- The ID of the pull request to retrieve.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestById: pullRequestId: float * ?project: string -> Promise<Git.GitPullRequest>
    /// <summary>Retrieve all pull requests matching a specified criteria.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="searchCriteria">- Pull requests will be returned that match this search criteria.</param>
    /// <param name="maxCommentLength">- Not used.</param>
    /// <param name="skip">- The number of pull requests to ignore. For example, to retrieve results 101-150, set top to 50 and skip to 100.</param>
    /// <param name="top">- The number of pull requests to retrieve.</param>
    abstract getPullRequestsByProject: project: string * searchCriteria: Git.GitPullRequestSearchCriteria * ?maxCommentLength: float * ?skip: float * ?top: float -> Promise<ResizeArray<Git.GitPullRequest>>
    /// <summary>Create a pull request.</summary>
    /// <param name="gitPullRequestToCreate">- The pull request to create.</param>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="supportsIterations">- If true, subsequent pushes to the pull request will be individually reviewable. Set this to false for large pull requests for performance reasons if this functionality is not needed.</param>
    abstract createPullRequest: gitPullRequestToCreate: Git.GitPullRequest * repositoryId: string * ?project: string * ?supportsIterations: bool -> Promise<Git.GitPullRequest>
    /// <summary>Retrieve a pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- The ID of the pull request to retrieve.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="maxCommentLength">- Not used.</param>
    /// <param name="skip">- Not used.</param>
    /// <param name="top">- Not used.</param>
    /// <param name="includeCommits">- If true, the pull request will be returned with the associated commits.</param>
    /// <param name="includeWorkItemRefs">- If true, the pull request will be returned with the associated work item references.</param>
    abstract getPullRequest: repositoryId: string * pullRequestId: float * ?project: string * ?maxCommentLength: float * ?skip: float * ?top: float * ?includeCommits: bool * ?includeWorkItemRefs: bool -> Promise<Git.GitPullRequest>
    /// <summary>Retrieve all pull requests matching a specified criteria.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="searchCriteria">- Pull requests will be returned that match this search criteria.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="maxCommentLength">- Not used.</param>
    /// <param name="skip">- The number of pull requests to ignore. For example, to retrieve results 101-150, set top to 50 and skip to 100.</param>
    /// <param name="top">- The number of pull requests to retrieve.</param>
    abstract getPullRequests: repositoryId: string * searchCriteria: Git.GitPullRequestSearchCriteria * ?project: string * ?maxCommentLength: float * ?skip: float * ?top: float -> Promise<ResizeArray<Git.GitPullRequest>>
    /// <summary>Update a pull request</summary>
    /// <param name="gitPullRequestToUpdate">- The pull request content that should be updated.</param>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request to update.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updatePullRequest: gitPullRequestToUpdate: Git.GitPullRequest * repositoryId: string * pullRequestId: float * ?project: string -> Promise<Git.GitPullRequest>
    /// <summary>Sends an e-mail notification about a specific pull request to a set of recipients</summary>
    /// <param name="userMessage">-</param>
    /// <param name="repositoryId">- ID of the git repository.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract sharePullRequest: userMessage: Git.ShareNotificationContext * repositoryId: string * pullRequestId: float * ?project: string -> Promise<unit>
    /// <summary>Create a pull request status.</summary>
    /// <param name="status">- Pull request status to create.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createPullRequestStatus: status: Git.GitPullRequestStatus * repositoryId: string * pullRequestId: float * ?project: string -> Promise<Git.GitPullRequestStatus>
    /// <summary>Delete pull request status.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="statusId">- ID of the pull request status.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract deletePullRequestStatus: repositoryId: string * pullRequestId: float * statusId: float * ?project: string -> Promise<unit>
    /// <summary>Get the specific pull request status by ID. The status ID is unique within the pull request across all iterations.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="statusId">- ID of the pull request status.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestStatus: repositoryId: string * pullRequestId: float * statusId: float * ?project: string -> Promise<Git.GitPullRequestStatus>
    /// <summary>Get all the statuses associated with a pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestStatuses: repositoryId: string * pullRequestId: float * ?project: string -> Promise<ResizeArray<Git.GitPullRequestStatus>>
    /// <summary>Update pull request statuses collection. The only supported operation type is \`remove\`.</summary>
    /// <param name="patchDocument">- Operations to apply to the pull request statuses in JSON Patch format.</param>
    /// <param name="repositoryId">- The repository ID of the pull request’s target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updatePullRequestStatuses: patchDocument: WebApi.JsonPatchDocument * repositoryId: string * pullRequestId: float * ?project: string -> Promise<unit>
    /// <summary>Create a comment on a specific thread in a pull request (up to 500 comments can be created per thread).</summary>
    /// <param name="comment">- The comment to create. Comments can be up to 150,000 characters.</param>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="threadId">- ID of the thread that the desired comment is in.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createComment: comment: Git.Comment * repositoryId: string * pullRequestId: float * threadId: float * ?project: string -> Promise<Git.Comment>
    /// <summary>Delete a comment associated with a specific thread in a pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="threadId">- ID of the thread that the desired comment is in.</param>
    /// <param name="commentId">- ID of the comment.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract deleteComment: repositoryId: string * pullRequestId: float * threadId: float * commentId: float * ?project: string -> Promise<unit>
    /// <summary>Retrieve a comment associated with a specific thread in a pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="threadId">- ID of the thread that the desired comment is in.</param>
    /// <param name="commentId">- ID of the comment.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getComment: repositoryId: string * pullRequestId: float * threadId: float * commentId: float * ?project: string -> Promise<Git.Comment>
    /// <summary>Retrieve all comments associated with a specific thread in a pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="threadId">- ID of the thread.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getComments: repositoryId: string * pullRequestId: float * threadId: float * ?project: string -> Promise<ResizeArray<Git.Comment>>
    /// <summary>Update a comment associated with a specific thread in a pull request.</summary>
    /// <param name="comment">- The comment content that should be updated. Comments can be up to 150,000 characters.</param>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="threadId">- ID of the thread that the desired comment is in.</param>
    /// <param name="commentId">- ID of the comment to update.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateComment: comment: Git.Comment * repositoryId: string * pullRequestId: float * threadId: float * commentId: float * ?project: string -> Promise<Git.Comment>
    /// <summary>Create a thread in a pull request.</summary>
    /// <param name="commentThread">- The thread to create. Thread must contain at least one comment.</param>
    /// <param name="repositoryId">- Repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createThread: commentThread: Git.GitPullRequestCommentThread * repositoryId: string * pullRequestId: float * ?project: string -> Promise<Git.GitPullRequestCommentThread>
    /// <summary>Retrieve a thread in a pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="threadId">- ID of the thread.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="iteration">- If specified, thread position will be tracked using this iteration as the right side of the diff.</param>
    /// <param name="baseIteration">- If specified, thread position will be tracked using this iteration as the left side of the diff.</param>
    abstract getPullRequestThread: repositoryId: string * pullRequestId: float * threadId: float * ?project: string * ?iteration: float * ?baseIteration: float -> Promise<Git.GitPullRequestCommentThread>
    /// <summary>Retrieve all threads in a pull request.</summary>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="iteration">- If specified, thread positions will be tracked using this iteration as the right side of the diff.</param>
    /// <param name="baseIteration">- If specified, thread positions will be tracked using this iteration as the left side of the diff.</param>
    abstract getThreads: repositoryId: string * pullRequestId: float * ?project: string * ?iteration: float * ?baseIteration: float -> Promise<ResizeArray<Git.GitPullRequestCommentThread>>
    /// <summary>Update a thread in a pull request.</summary>
    /// <param name="commentThread">- The thread content that should be updated.</param>
    /// <param name="repositoryId">- The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="threadId">- ID of the thread to update.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateThread: commentThread: Git.GitPullRequestCommentThread * repositoryId: string * pullRequestId: float * threadId: float * ?project: string -> Promise<Git.GitPullRequestCommentThread>
    /// <summary>Retrieve a list of work items associated with a pull request.</summary>
    /// <param name="repositoryId">- ID or name of the repository.</param>
    /// <param name="pullRequestId">- ID of the pull request.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getPullRequestWorkItemRefs: repositoryId: string * pullRequestId: float * ?project: string -> Promise<ResizeArray<WebApi.ResourceRef>>
    /// <summary>Push changes to the repository.</summary>
    /// <param name="push">-</param>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createPush: push: Git.GitPush * repositoryId: string * ?project: string -> Promise<Git.GitPush>
    /// <summary>Retrieves a particular push.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="pushId">- ID of the push.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeCommits">- The number of commits to include in the result.</param>
    /// <param name="includeRefUpdates">- If true, include the list of refs that were updated by the push.</param>
    abstract getPush: repositoryId: string * pushId: float * ?project: string * ?includeCommits: float * ?includeRefUpdates: bool -> Promise<Git.GitPush>
    /// <summary>Retrieves pushes associated with the specified repository.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="skip">- Number of pushes to skip.</param>
    /// <param name="top">- Number of pushes to return.</param>
    /// <param name="searchCriteria">- Search criteria attributes: fromDate, toDate, pusherId, refName, includeRefUpdates or includeLinks. fromDate: Start date to search from. toDate: End date to search to. pusherId: Identity of the person who submitted the push. refName: Branch name to consider. includeRefUpdates: If true, include the list of refs that were updated by the push. includeLinks: Whether to include the _links field on the shallow references.</param>
    abstract getPushes: repositoryId: string * ?project: string * ?skip: float * ?top: float * ?searchCriteria: Git.GitPushSearchCriteria -> Promise<ResizeArray<Git.GitPush>>
    /// <summary>Destroy (hard delete) a soft-deleted Git repository.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- The ID of the repository.</param>
    abstract deleteRepositoryFromRecycleBin: project: string * repositoryId: string -> Promise<unit>
    /// <summary>Retrieve soft-deleted git repositories from the recycle bin.</summary>
    /// <param name="project">- Project ID or project name</param>
    abstract getRecycleBinRepositories: project: string -> Promise<ResizeArray<Git.GitDeletedRepository>>
    /// <summary>Recover a soft-deleted Git repository. Recently deleted repositories go into a soft-delete state for a period of time before they are hard deleted and become unrecoverable.</summary>
    /// <param name="repositoryDetails">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- The ID of the repository.</param>
    abstract restoreRepositoryFromRecycleBin: repositoryDetails: Git.GitRecycleBinRepositoryDetails * project: string * repositoryId: string -> Promise<Git.GitRepository>
    /// <summary>Queries the provided repository for its refs and returns them.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="filter">- [optional] A filter to apply to the refs (starts with).</param>
    /// <param name="includeLinks">- [optional] Specifies if referenceLinks should be included in the result. default is false.</param>
    /// <param name="includeStatuses">- [optional] Includes up to the first 1000 commit statuses for each ref. The default value is false.</param>
    /// <param name="includeMyBranches">- [optional] Includes only branches that the user owns, the branches the user favorites, and the default branch. The default value is false. Cannot be combined with the filter parameter.</param>
    /// <param name="latestStatusesOnly">- [optional] True to include only the tip commit status for each ref. This option requires \`includeStatuses\` to be true. The default value is false.</param>
    /// <param name="peelTags">- [optional] Annotated tags will populate the PeeledObjectId property. default is false.</param>
    /// <param name="filterContains">- [optional] A filter to apply to the refs (contains).</param>
    abstract getRefs: repositoryId: string * ?project: string * ?filter: string * ?includeLinks: bool * ?includeStatuses: bool * ?includeMyBranches: bool * ?latestStatusesOnly: bool * ?peelTags: bool * ?filterContains: string -> Promise<ResizeArray<Git.GitRef>>
    /// <summary>Lock or Unlock a branch.</summary>
    /// <param name="newRefInfo">- The ref update action (lock/unlock) to perform</param>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="filter">- The name of the branch to lock/unlock</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="projectId">- ID or name of the team project. Optional if specifying an ID for repository.</param>
    abstract updateRef: newRefInfo: Git.GitRefUpdate * repositoryId: string * filter: string * ?project: string * ?projectId: string -> Promise<Git.GitRef>
    /// <summary>Creating, updating, or deleting refs(branches).</summary>
    /// <param name="refUpdates">- List of ref updates to attempt to perform</param>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="projectId">- ID or name of the team project. Optional if specifying an ID for repository.</param>
    abstract updateRefs: refUpdates: ResizeArray<Git.GitRefUpdate> * repositoryId: string * ?project: string * ?projectId: string -> Promise<ResizeArray<Git.GitRefUpdateResult>>
    /// <summary>Creates a ref favorite</summary>
    /// <param name="favorite">- The ref favorite to create.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createFavorite: favorite: Git.GitRefFavorite * project: string -> Promise<Git.GitRefFavorite>
    /// <summary>Deletes the refs favorite specified</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="favoriteId">- The Id of the ref favorite to delete.</param>
    abstract deleteRefFavorite: project: string * favoriteId: float -> Promise<unit>
    /// <summary>Gets the refs favorite for a favorite Id.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="favoriteId">- The Id of the requested ref favorite.</param>
    abstract getRefFavorite: project: string * favoriteId: float -> Promise<Git.GitRefFavorite>
    /// <summary>Gets the refs favorites for a repo and an identity.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- The id of the repository.</param>
    /// <param name="identityId">- The id of the identity whose favorites are to be retrieved. If null, the requesting identity is used.</param>
    abstract getRefFavorites: project: string * ?repositoryId: string * ?identityId: string -> Promise<ResizeArray<Git.GitRefFavorite>>
    /// <summary>Create a git repository in a team project.</summary>
    /// <param name="gitRepositoryToCreate">- Specify the repo name, team project and/or parent repository. Team project information can be ommitted from gitRepositoryToCreate if the request is project-scoped (i.e., includes project Id).</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="sourceRef">- [optional] Specify the source refs to use while creating a fork repo</param>
    abstract createRepository: gitRepositoryToCreate: Git.GitRepositoryCreateOptions * ?project: string * ?sourceRef: string -> Promise<Git.GitRepository>
    /// <summary>Delete a git repository</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract deleteRepository: repositoryId: string * ?project: string -> Promise<unit>
    /// <summary>Retrieve git repositories.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="includeLinks">- [optional] True to include reference links. The default value is false.</param>
    /// <param name="includeAllUrls">- [optional] True to include all remote URLs. The default value is false.</param>
    /// <param name="includeHidden">- [optional] True to include hidden repositories. The default value is false.</param>
    abstract getRepositories: ?project: string * ?includeLinks: bool * ?includeAllUrls: bool * ?includeHidden: bool -> Promise<ResizeArray<Git.GitRepository>>
    /// <summary>Retrieve a git repository.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getRepository: repositoryId: string * ?project: string -> Promise<Git.GitRepository>
    /// <summary>Retrieve a git repository.</summary>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="includeParent">- True to include parent repository. Only available in authenticated calls.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getRepositoryWithParent: repositoryId: string * includeParent: bool * ?project: string -> Promise<Git.GitRepository>
    /// <summary>Updates the Git repository with either a new repo name or a new default branch.</summary>
    /// <param name="newRepositoryInfo">- Specify a new repo name or a new default branch of the repository</param>
    /// <param name="repositoryId">- The name or ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract updateRepository: newRepositoryInfo: Git.GitRepository * repositoryId: string * ?project: string -> Promise<Git.GitRepository>
    /// <summary>Starts the operation to create a new branch which reverts changes introduced by either a specific commit or commits that are associated to a pull request.</summary>
    /// <param name="revertToCreate">-</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- ID of the repository.</param>
    abstract createRevert: revertToCreate: Git.GitAsyncRefOperationParameters * project: string * repositoryId: string -> Promise<Git.GitRevert>
    /// <summary>Retrieve information about a revert operation by revert Id.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="revertId">- ID of the revert operation.</param>
    /// <param name="repositoryId">- ID of the repository.</param>
    abstract getRevert: project: string * revertId: float * repositoryId: string -> Promise<Git.GitRevert>
    /// <summary>Retrieve information about a revert operation for a specific branch.</summary>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="repositoryId">- ID of the repository.</param>
    /// <param name="refName">- The GitAsyncRefOperationParameters generatedRefName used for the revert operation.</param>
    abstract getRevertForRefName: project: string * repositoryId: string * refName: string -> Promise<Git.GitRevert>
    /// <summary>Create Git commit status.</summary>
    /// <param name="gitCommitStatusToCreate">- Git commit status object to create.</param>
    /// <param name="commitId">- ID of the Git commit.</param>
    /// <param name="repositoryId">- ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract createCommitStatus: gitCommitStatusToCreate: Git.GitStatus * commitId: string * repositoryId: string * ?project: string -> Promise<Git.GitStatus>
    /// <summary>Get statuses associated with the Git commit.</summary>
    /// <param name="commitId">- ID of the Git commit.</param>
    /// <param name="repositoryId">- ID of the repository.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="top">- Optional. The number of statuses to retrieve. Default is 1000.</param>
    /// <param name="skip">- Optional. The number of statuses to ignore. Default is 0. For example, to retrieve results 101-150, set top to 50 and skip to 100.</param>
    /// <param name="latestOnly">- The flag indicates whether to get only latest statuses grouped by \`Context.Name\` and \`Context.Genre\`.</param>
    abstract getStatuses: commitId: string * repositoryId: string * ?project: string * ?top: float * ?skip: float * ?latestOnly: bool -> Promise<ResizeArray<Git.GitStatus>>
    /// <summary>Retrieve a pull request suggestion for a particular repository or team project.</summary>
    /// <param name="repositoryId">- ID of the git repository.</param>
    /// <param name="project">- Project ID or project name</param>
    abstract getSuggestions: repositoryId: string * ?project: string -> Promise<ResizeArray<Git.GitSuggestion>>
    /// <summary>The Tree endpoint returns the collection of objects underneath the specified tree. Trees are folders in a Git repository.</summary>
    /// <param name="repositoryId">- Repository Id.</param>
    /// <param name="sha1">- SHA1 hash of the tree object.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="projectId">- Project Id.</param>
    /// <param name="recursive">- Search recursively. Include trees underneath this tree. Default is false.</param>
    /// <param name="fileName">- Name to use if a .zip file is returned. Default is the object ID.</param>
    abstract getTree: repositoryId: string * sha1: string * ?project: string * ?projectId: string * ?recursive: bool * ?fileName: string -> Promise<Git.GitTreeRef>
    /// <summary>The Tree endpoint returns the collection of objects underneath the specified tree. Trees are folders in a Git repository.</summary>
    /// <param name="repositoryId">- Repository Id.</param>
    /// <param name="sha1">- SHA1 hash of the tree object.</param>
    /// <param name="project">- Project ID or project name</param>
    /// <param name="projectId">- Project Id.</param>
    /// <param name="recursive">- Search recursively. Include trees underneath this tree. Default is false.</param>
    /// <param name="fileName">- Name to use if a .zip file is returned. Default is the object ID.</param>
    abstract getTreeZip: repositoryId: string * sha1: string * ?project: string * ?projectId: string * ?recursive: bool * ?fileName: string -> Promise<ArrayBuffer>

type [<AllowNullLiteral>] GitRestClientStatic =
    [<Emit "new $0($1...)">] abstract Create: options: IVssRestClientOptions -> GitRestClient
    abstract RESOURCE_AREA_ID: string
