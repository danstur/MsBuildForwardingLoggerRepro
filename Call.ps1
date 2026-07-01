param(
    [Parameter(Mandatory)]
    $SolutionOrProject,
    [Parameter()]
    $Msbuild = "C:\Program Files\Microsoft Visual Studio\18\Professional\MSBuild\Current\Bin\msbuild.exe"
)

Push-Location $PSScriptRoot
try {
    dotnet build --configuration Debug
    $loggerDll = "$PSScriptRoot\bin\Debug\netstandard2.0\MsBuildForwardingLoggerRepro.dll"
    . $Msbuild $SolutionOrProject `
        /t:rebuild `
        /nodeReuse:false `
        /DistributedLogger:"MyCentralLogger,$loggerDll*MyForwardingLogger,$loggerDll"

} finally {
    Pop-Location
}
 