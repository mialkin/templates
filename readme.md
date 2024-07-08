# Templates

This solution contains [↑ custom template](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates) for `dotnet new` command. 

## How to use template

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
--main-entity-name=MAIN_ENTITY_NAME \
--force
```

Example:

```csharp
dotnet new skeleton-api \
--name=Company.Blog \
--api-port=8040 \
--postgres-port=8050 \
--main-entity-name=User \
--force
```

At the end type `y` to confirm running `dotnet format` [↑ post action](https://github.com/dotnet/templating/wiki/Post-Action-Registry), which is necessary for sorting `using` directives.

### 3\. Initialize Git repository and create first commit 

```bash
git init && git add . && git commit --message "Initial commit"
```