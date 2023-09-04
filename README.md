# QuickChess
QuickChess é um projeto Opensource de portifolio, que tem como objetivo desenvolver uma plataforma para jogar xadres (e futuramente outros jogos similares) com outras pessoas de forma rapida. Dessa forma todo o funcionamento do [backend](https://github.com/GabrielMaia-Dev/quick-chess/wiki/Backend) e [front](https://github.com/GabrielMaia-Dev/quick-chess/wiki/Frontend) end é documentado no aspecto de arquitetura e funcionamento.

# Como rodar o projeto?
Para rodar o projeto basta executar os projetos (front e backend) de forma separada

### frontend
pasta app `ng serve` (necessário node 20)

### backend
pasta backend `dotnet run --project Api` (necessario dotnet 7)

# Como buildar o projeto?
Para buildar o projeto para distribuição é necessário rodar os seguintes comandos

### frontend
pasta app (necessário node 20)

`ng build`

Os arquivos de distribuição estarão na pasta `dist/app`, esses arquivos serão usados no build do backend para gerar os arquivos de distribuiçao finais.


### backend
pasta backend (necessario dotnet 7)
Após buildar o frontend, deve-se copiar os arquivos de build gerados na pasta app/dist/app o cola-los na pasta backend/Api/wwwroot.

`dotnet publish -c Release -o dist`

Os arquivos finais de distribuição estarão na pasta `dist`.

# Como contribuir?
Contribuições podem ser feitas atravez de PRs, apenas sendo necessário atentar para o fato de caso haja alguma alteração nos arquivos do frontend é necessário fazer commit incluindo os arquivos de distribuição do front (descrito na etapa 'Como buildar o projeto?' seção backend).

