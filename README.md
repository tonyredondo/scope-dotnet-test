# Scope: Getting Started

An starter ASP.NET Core + React project instrumented with [Scope](https://scope.undefinedlabs.com) through [GitHub Actions](https://github.com/features/actions).

This starter project is based on:
- [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Install Scope on .NET Core projects with GitHub Actions

The `scope-for-dotnet-action` action has been configured in the GitHub Workflow `scope.yml` file:

```yaml
name: Build and run Tests 
on: [push]
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v1
    - name: Setup .NET Core
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 3.1.100
    - name: Build with dotnet
      run: dotnet build
    - name: Scope for .NET
      uses: undefinedlabs/scope-for-dotnet-action@v1
      with:
        dsn: ${{ secrets.SCOPE_DSN }}
```

For further information about how to install Scope, go to [Scope .NET Agent Installation](https://docs.scope.dev/docs/dotnet-installation)

## Running Scope on GitHub Actions

1. Click on `Use this template` button and create the repository in your namespace.
2. Access to [app.scope.dev](https://app.scope.dev) and 
3. Add/Modify your namespace to include your new repository.
4. Get the API Key for your new repository.
5. Go to your repository on [GitHub](https://github.com)
6. Go to `Settings` -> `Secrets`.
7. Add your API Key secret.
    - Name: `SCOPE_DSN`
    - Value: `https://<<your APIKEY>>@app.scope.dev`
8. Click on `Actions` button and access to the workflow.
9. Click on `Re-run checks`.

Once GitHub Workflow has finished, you can check the test executions report on [app.scope.dev](https://app.scope.dev) 
