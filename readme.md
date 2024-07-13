# Templates

This solution contains [↑ custom template](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates) for `dotnet new` command. 

## How to use template

### 1\. Select folder with template you want to install

```bash
cd skeleton-cqrs
```

or:

```bash
cd skeleton-console
```


### 2\. Install template

```bash
dotnet new install ./ --force
# dotnet new uninstall ./ # Uninstalls template
```

### 3\. Create new solution based on installed template

```bash
mkdir SOLUTION_FOLDER && cd "$_"
```

```bash
dotnet new skeleton-cqrs \
--name=SOLUTION_NAME \
--api-port=API_PORT \
--postgres-port=POSTGRES_PORT \
--main-entity-name=MAIN_ENTITY_NAME \
--force
```

or:

```bash
dotnet new skeleton-console \
--name=SOLUTION_NAME \
--force
```

Example:

```bash
mkdir company-notes && cd "$_"
```

```bash
dotnet new skeleton-cqrs \
--name=Company.Notes \
--api-port=8040 \
--postgres-port=8050 \
--main-entity-name=User \
--force
```

At the end type `y` to confirm running `dotnet format` [↑ post action](https://github.com/dotnet/templating/wiki/Post-Action-Registry), which is necessary for sorting `using` directives:

```console
The template "Skeleton Web API" was created successfully.

Processing post-creation actions...
Template is configured to run the following action:
Actual command: dotnet format
Do you want to run this action [Y(yes)|N(no)]?
y
Running command 'dotnet format'...
Command succeeded.
```

### 4\. Initialize Git repository and create first commit 

```bash
git init && git add . && git commit --message "Initial commit"
```