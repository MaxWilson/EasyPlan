# EasyPlan

An Azure Devops Services extension for visualizing workflow.

Written using [Fable](http://fable.io/), [Elmish](https://fable-elmish.github.io/) and [Feliz](https://github.com/Zaid-Ajaj/Feliz).

## Dev reference of useful commands and URLs

    choco install mkcert
    mkcert -install
    mkcert localhost
    npm install -g tfx-cli
    npx tfx-cli extension create
    https://marketplace.visualstudio.com/manage/publishers/maxwilson
    https://aka.ms/vsmarketplace-manage
    https://dev.azure.com/maxw0485/maxw
    npm start

## Requirements

* [dotnet SDK](https://www.microsoft.com/net/download/core) 2.0.0 or higher
* [node.js](https://nodejs.org) 10.0.0 or higher

## Editor

To write and edit your code, you can use either VS Code + [Ionide](http://ionide.io/), Emacs with [fsharp-mode](https://github.com/fsharp/emacs-fsharp-mode), [Rider](https://www.jetbrains.com/rider/) or Visual Studio.


## Development

Before doing anything, start with installing npm dependencies using `npm install`.

Then make sure you have a certificate that can be used by https for localhost:

```bash
mkcert -install
mkcert localhost
```

Then to start development mode with hot module reloading, run:
```bash
npm start
```

This will start the development server after compiling the project, once it is finished, navigate to [EasyPlan in Azure Devops](https://dev.azure.com/maxw0485/maxw/_apps/hub/MaxWilson.EasyPlan.EasyPlan), which internally refers to http://localhost:8080. Every time you make a change, webpack will use hot-module reloading to update your browser with the new code.

In order to use EasyPlan to make cross-tenant ADO queries (i.e. real data from your actual team while you are developing), you will need to create a PAT by following instructions at EasyPlan's Help link.

To build the application and make ready for production:
```
npm run publishOsgs
```
This command builds the extension as a VSIX that you can then upload to https://marketplace.visualstudio.com/manage/publishers/maxwilson or elsewhere.

