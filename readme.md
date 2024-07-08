# Templates

## How to use project

### 1\. Install template on your computer

```bash
cd skeleton-api
dotnet new install ./ --force
# dotnet new uninstall ./ # Uninstalls template
```

### 2\. Create new solution based on installed template

Run this commands from a new folder where you want your solution to be created:

```bash
dotnet new skeleton-api \
--name=SOLUTION_NAME \
--api-port=API_PORT \
--postgres-port=POSTGRES_PORT \
--force

git init && git add . && git commit -m "Initial commit"
```

Example:

```csharp
dotnet new skeleton-api \
--name=Blog \
--api-port=8040 \
--postgres-port=8050 \
--main-entity-name=User \
--force
```

At the end confirm running `dotnet format` command, which is primarily needed for sorting `using` directives.

### 3\. Initialize Git repository and create first commit 

```bash
git init && git add . && git commit -m "Initial commit"
```