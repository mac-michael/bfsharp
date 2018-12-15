param($installPath, $toolsPath, $package, $project)

[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.Build") | out-null

$buildProject = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

$uri = new-object System.Uri($installPath);
$uri2 = new-object System.Uri($buildProject.DirectoryPath+"\");
$path = $uri2.MakeRelativeUri($uri)

$group = $buildProject.Xml.AddPropertyGroup()
$group.AddProperty("PostSharpSearchPath", "$" + "(PostSharpSearchPath);" + $path + "\lib\35")

$buildProject.Save()


$snippetFolder = "BFsharp"
$source = "$toolsPath\*.snippet"
$vsVersions = @("2010")

Foreach ($vsVersion in $vsVersions)
{
    $myCodeSnippetsFolder = "$HOME\My Documents\Visual Studio $vsVersion\Code Snippets\Visual C#\My Code Snippets\"
    if (Test-Path $myCodeSnippetsFolder)
    {
        $destination = "$myCodeSnippetsFolder$snippetFolder"
        if (!($myCodeSnippetsFolder -eq $destination))
        {
            if (!(Test-Path $destination))
            {
                New-Item $destination -itemType "directory"
            }
  
            "Installing code snippets for Visual Studio $vsVersion"
            Copy-Item $source $destination
        }
        else
        {
            "Define a value for snippetFolder variable, cannot be empty"
        }
    }
}