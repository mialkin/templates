# Skeleton

## Prerequisites

- [↑ .NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [↑ EF Core command-line tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- [↑ Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [↑ GNU Make](https://www.gnu.org/software/make)

## Running project

```bash
# Run Postgres in Docker
make run-infrastructure

# Crete initial database migration
make migrate-database name="Add_Initial_Migration" environment="Ide"

# Apply migration
make update-database environment="Ide"

# Run application. To stop application press CTRL + C
make run

# Delete Postgres container after application stop
make shutdown-infrastructure
```
