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
