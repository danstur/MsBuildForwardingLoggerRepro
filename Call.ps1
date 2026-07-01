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
        /p:platform="x64" /p:configuration="Debug" `
        /t:rebuild `
        /nodeReuse:false `
        "/distributedLogger:MyCentralLogger,$loggerDll*MyForwardingLogger,$loggerDll"

} finally {
    Pop-Location
}
 