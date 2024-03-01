# API Validadora De Senhas (WEB API .NET) - Frattina


Versão MVC UI + API             |  Apenas API Backend
:-------------------------:|:-------------------------:
<img src="https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/cd822458-9735-4931-ae6d-086619928658" width=100%>  |  <img src="https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/4b9ee946-e564-4aea-8257-0dd426b1191a" width=100%> 

Esta solução foi desenvolvida com o intuito de validar a força de uma senha digitada pelo usuário, de acordo com algumas premissas basicas para uma senha forte. A solução conta com um projeto de WEB API .NET e um projeto simples MVC, sendo permitida a execução separada ou mútua dos projetos, mais detalhes serão descritos nas instruções de execução da aplicação.



## Requisitos para a execução da aplicação
- Framework .NET Core 8 **(Imprescindível)**
- Visual Studio 2022 version 17.8+ <br/>

**As versões de ambiente são de suma importancia para que não ocorram erros na execução!**

(Não foram utilizados pacotes NuGet nesta solução e nem conexões de banco de dados)

# Instruções para a execução da aplicação
Abaixo você verá instruções de como executar a aplicação de duas formas. **A primeira, executando apenas a API**, utilizando a interface do Swagger para testar as requisições e respostas diretamente no formato JSON. **A segunda, executando a solução completa**, utilizando o projeto UI que consome API construída.

## Executando apenas o projeto de API.

<details>
<summary> Clique aqui para ver o passo a passo</summary>
<br/>
Com a solução aberta, clique com o botão direito no projeto ValidadorSenhaAPI, e em seguida, defina-o como Projeto de Inicialização:  

![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/05b60e4d-7d69-4eeb-9f2a-869fadee860b)


Em seguida, basta clicar para iniciar a aplicação: 

![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/cc38e921-56f1-4847-895d-fc2d813d6de2)



Com a aplicação rodando, clique em Try it out:

<img src="https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/cac243bb-c463-4abd-a56a-5bb7d389a549" width=50%>
<br/>

Feito isso, preencha a chave senha no JSON e clique em execute, a API retornará um JSON resposta, conténdo as tratativas da senha digitada:

<img src="https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/8c2e50e1-0200-43e7-a600-843aadd5d2a5" width=80%>

</details>



## Executando a solução com o MVC consumindo a API.

<details>
<summary> Clique aqui para ver o passo a passo</summary>

<br/>

Com a solução aberta, clique com o botão direito sobre a mesma, e em seguida clique em propriedades:  
![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/5269192b-0e2a-4eec-89a8-dca77a1e8a43)


Na janela aberta, selecione os dois projetos como Iniciar, e confirme:

![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/007e7a49-96ba-4fb6-ac67-f7072ed8a21e)


Após isso, basta clicar em iniciar:

![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/8fc61931-cd87-41b1-bc3b-ce0dcc55e2ad)


O projeto de API e UI serão executados, na UI, basta digitar as senhas que deseja validar e receber o resultado em tempo real:

![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/dfd70d8c-f51c-4760-87b6-40d303c72ace)


Nota: é possível visualizar o JSON de resposta da API ao clicar no link abaixo de verificar:

![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/5161745d-1cbe-4e53-84cb-47f755d88148)


</details>

## 🛠 Detalhes sobre a solução (Construção, Codigo, Tomada de decisão, etc)

Nesta seção, irei explicar como a solução foi construída visando ser simples, ter um codigo limpo, de facil entendimento e manutenção, e ao mesmo tempo ser bem abstraída e escalável.

Aqui listarei os detalhes do foco principal, que é o **projeto de API**, o MVC é apenas um adicional simples, que fiz para complementar o cenário e exercitar a mente.

A ideia inicial era justamente criar uma API que fosse bem organizada, de facil manutenção e fácil de se implementar novas funcionalidades, por este motivo, decidi separar a aplicação em camadas e metodos, uma camada para logica de negocio (BLL), uma para os repositorios e interfaces (as quais implementam metodos genéricos para suas funcionalidades).

_Nota: A API só retornará status 400 (Bad Request) quando o input obrigatório não for preenchido._
 
 Separação das Camadas           |  Separação dos Metodos
:-------------------------:|:-------------------------:
<img src="https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/586266b7-4a29-4acf-8577-b11b991947aa"> | <img src="https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/b9f6ae04-a1cd-4f19-8ad5-02b08bb24da6">

Abaixo está um exemplo de método genérico, que engloba funções que façam sentido para ele, dessa forma evitando condicionais que poluam uma controladora ou uma camada de logica:

Visão de Clean Code             | 
:-------------------------:|
![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/5aad0247-d6aa-48c1-82b0-4ffea232a33e)

Decidi também fazer com que a camada de logica fosse a mais simples e legível possível, tambem achei que seria melhor manter o padrão de string[] para o retorno dos erros, pois é bastante utilizado em formatos JSON:

BLL após removida da Controladora| 
:-------------------------:|
![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/da14e88c-7a84-49b3-98bb-767bdcb0d4c1)

Para mim, a controladora deve ser pura, com o mínimo de codigo possível, pois seu papel é dar as ordens e receber respostas, por isso sempre tento abstrair o máximo que consigo:

Controladora | 
:-------------------------:|
![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/154c082a-dcc0-40c8-a8b2-e7e6d99bfc95)

Sobre o projeto de API, creio que esses são os pontos mais fortes do codigo, fique a vontade para explorar o restante do projeto!

## Documentação da API

```http
  POST /api/ValidadorSenhaAPI/
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `senha` | `string` | **Obrigatório**. Senha a ser validada pela API. |

#### Retorna um item

| Chave   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `senhaValida`      | `boolean` | Indica se a senha é valida ou não após passar pela API. |
| `erros`      | `string[]` | Lista um array de string com os critérios que reprovaram a senha. |


#### Possiveis problemas ao executar a aplicação 🔍

- Erro de certificado (Pagina não confiável ou segura / NET::ERR_CERT_INVALID)

Caso o erro acima aconteça, é bem possível que seu navegador esteja configurado para não confiar em certificados SSL de um localhost, o que inviabiliza o uso da aplicação dessa forma. Para corrigir deve-se alterar a configuração do navegador, um exemplo no Google Chrome:

Pesquisar por chrome://flags/#allow-insecure-localhost

Trocar de disabled para Enabled.
![image](https://github.com/FelipeRDEV/API_Validadora_De_Senha/assets/87353123/b7be4262-718d-482e-8ff3-89efa371b552)


É possível (raro, mas possível) que as portas que a aplicação utiliza não estejam disponíveis em seu modem/roteador, portanto, caso ocorram falhas nas chamadas de api por tais motivos, verifique os arquivos de configuração dos projetos (launchSettings.json) e configure uma porta disponível em seu ambiente.

Caso ocorra algum erro que indique que a aplicação não pode ser executada por uma porta, porém também há uma mensagem para confirmar se o .NET Core está instalado, verifique a versão do seu framework (dotnet --version).
