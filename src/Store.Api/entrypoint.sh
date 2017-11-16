#!/bin/bash

set -e
run_cmd="dotnet run"

cd "../Store.Migrations"
until dotnet ef database update -c CoreDbContext; do
>&2 echo "Applying database migrations..."
sleep 1 
done

>&2 echo "Database migrations applied."
cd "../Store.Api"
exec $run_cmd