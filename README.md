# How to run MoneyAdmin.WebApi Project via command line

1. Create containers based on the \*.yml listed.
    `docker-compose -f docker-compose.yml -f docker-compose.override.yml -f docker-compose.override.cli.yml --no-ansi up -d --force-recreate --remove-orphans`
1. Get informations about the MoneyAdmin.WebApi Container.
    `docker ps --filter "status=running" --filter "name=MoneyAdmin.WebApi"`
1. Using the MoneyAdmin.WebApi Container Id from `docker ps` command, run the application inside the container.
    `docker exec -i -d <container_id> sh -c "dotnet --additionalProbingPath /root/.nuget/packages --additionalProbingPath /root/.nuget/fallbackpackages bin/Debug/netcoreapp3.1/MoneyAdmin.WebApi.dll | tee /dev/console"`
1. Using the MoneyAdmin.WebApi Container Port from `docker ps` command, access the swagger service.
    `http://localhost:<container_port>/swagger/index.html`
1. Stop and remove containers.
    `docker-compose -f docker-compose.yml -f docker-compose.override.yml -f docker-compose.override.cli.yml --no-ansi down`