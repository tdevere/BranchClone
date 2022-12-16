Set-Location 'd:\'
$sourceDirectory = 'd:\BranchLoop'
$repositoryUrl

$NewBranchCount = 200


[bool]$CloneNeeded = $false
if([System.IO.Directory]::Exists($sourceDirectory))
{
    Write-Host "Source Exists"
    Get-ChildItem -Path $sourceDirectory | Where-Object {$_.CreationTime -gt (Get-Date).Date}   
}
else
{
    Write-Host "Source Doesn't Exist"
    #PowerShell Create directory if not exists
    New-Item $sourceDirectory -ItemType Directory
    $CloneNeeded = $true
}

if ($CloneNeeded)
{
    git clone 'https://github.com/tdevere/BranchClone.git'
}

Set-Location $sourceDirectory
Get-ChildItem -Path $sourceDirectory

[bool]$CreateBranch = $false
for ($i=0; $i -le $NewBranchCount; $i++)
{   
    #delete branches
    #git push -d origin $i #Remote
    #git branch -d $i #Local


    $branchDirectory = $sourceDirectory + "\" + $i
    $branchDirectory
    if([System.IO.Directory]::Exists($branchDirectory))
    {
        if ((Get-ChildItem -Path $branchDirectory -Recurse).Count -ge 0)
        {
            $CreateBranch = $false
        }
        else 
        {            
            $CreateBranch = $true
        }
    }
    else 
    {
        New-Item $branchDirectory -ItemType Directory
    }

    $outfile = "$branchDirectory" + "\" + $i + ".txt"
    git branch $i    
    git checkout $i
    git remote add origin 'https://github.com/tdevere/BranchClone.git'       
    Get-Date | Out-File -FilePath $outfile -Append -Force
    git add .
    git commit -m $branchDirectory
    git push -u origin $i
    git checkout main
    #git branch -l    
}
