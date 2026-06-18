#!/usr/bin/env pwsh
<##
Helper script to run the ListaDeTarefas project from the repository root.
Usage (PowerShell):
  .\run.ps1
It executes:
  dotnet run --project .\ListaDeTarefas\ListaDeTarefas.csproj
##>

$project = Join-Path $PSScriptRoot 'ListaDeTarefas\ListaDeTarefas.csproj'
if (-not (Test-Path $project)) {
    Write-Error "Projeto não encontrado: $project"
    exit 1
}

Write-Host "Executando projeto: $project" -ForegroundColor Cyan
& dotnet run --project $project
