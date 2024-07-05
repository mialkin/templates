# Templates

Install template:

```bash
cd skeleton-api
dotnet new install ./ --force
```

Use template:

```bash
dotnet new skeleton-api \
--name=SOLUTION_NAME \
--api-port=API_PORT \
--postgres-port=POSTGRES_PORT \
--force
```

Uninstall template:

```bash
dotnet new uninstall ./
```
