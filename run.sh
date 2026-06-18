#!/usr/bin/env bash
# Helper script to run the ListaDeTarefas project from the repository root.
# Usage: ./run.sh
project="$(pwd)/ListaDeTarefas/ListaDeTarefas.csproj"
if [ ! -f "$project" ]; then
  echo "Projeto não encontrado: $project"
  exit 1
fi

echo "Executando projeto: $project"
dotnet run --project "$project"
