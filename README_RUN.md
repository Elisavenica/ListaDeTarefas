Se o comando `dotnet run` não encontrar o projeto, use os scripts abaixo no diretório raiz do repositório:

PowerShell:
  .\run.ps1

Bash:
  ./run.sh

Os scripts executam:
  dotnet run --project ./ListaDeTarefas/ListaDeTarefas.csproj

Ou, abra a pasta `ListaDeTarefas` e rode:
  dotnet run

Se persistir erro, execute `Get-ChildItem -Recurse -Filter *.csproj` e cole a saída aqui.