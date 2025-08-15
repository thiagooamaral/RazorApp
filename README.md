# 📄 ASP.NET Razor Pages — Guia e Anotações

> Curso: [Uma visão geral do ASP.NET Razor Pages](https://balta.io/cursos/uma-visao-geral-do-aspnet-razor-pages)

Este repositório contém um projeto de estudo e anotações sobre **ASP.NET Razor Pages**, com foco em organização, clareza e boas práticas no desenvolvimento web *page-based*.

---

## 🧠 Conceitos Fundamentais

| Conceito   | Descrição |
|------------|-----------|
| **C#**     | Linguagem de programação utilizada no desenvolvimento com Razor Pages. |
| **.NET**   | Plataforma de desenvolvimento que fornece bibliotecas e infraestrutura para aplicações (desktop, web, mobile etc.). |
| **ASP.NET**| Framework web que roda sobre o .NET e permite construir aplicações web do lado do servidor. |
| **Blazor** | Framework do .NET que permite rodar C# também no lado do cliente (via WebAssembly ou server-side). |
| **Razor**  | Motor de renderização (*view engine*) usado em ASP.NET que permite mesclar C# e HTML para gerar páginas dinâmicas de forma simples. |

---

## 🛠️ Comandos Úteis

```bash
# Ver versão atual do .NET SDK
dotnet --version

# Listar todos os SDKs instalados
dotnet --list-sdks

# Criar um arquivo global.json para definir uma versão específica do SDK
dotnet new globaljson --sdk-version 7.0.400

# Criar novo projeto web com Razor Pages
dotnet new web -o MyRazoApp
```

---

## 🖥️ Estrutura Básica de um Projeto Razor Pages

```csharp
var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte às Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Middlewares
app.UseHttpsRedirection();   // Redireciona para HTTPS
app.UseStaticFiles();        // Permite uso de arquivos estáticos da pasta wwwroot
app.UseRouting();            // Habilita o roteamento

// Mapeia as páginas Razor
app.MapRazorPages();

app.Run();
```

---

## 📄 Estrutura de uma Página Razor (.cshtml)

- Começa com a diretiva `@page`.
- Usa `@model` para conectar a view com a classe C# (*PageModel*).
- Permite inserir C# dentro do HTML usando `@`.
- Arquivo `.cshtml.cs` complementar contém a lógica da página.

**Exemplo simples:**

```razor
@page
@model IndexModel
<h1>Olá, @Model.Nome!</h1>
```

```csharp
public class IndexModel : PageModel
{
    public string Nome { get; set; } = "Mundo";
}
```

---

## 💡 Por que usar Razor Pages?

✅ Mais organizado que Web Forms  
✅ Boa separação entre lógica (C#) e interface (HTML)  
✅ Ideal para aplicações baseadas em páginas (*page-based*)  
✅ Fácil aprendizado para quem já conhece C# e HTML  

> **Dica:** Sempre inicialize listas e propriedades usadas no `.cshtml` fora dos métodos (`OnGet`, `OnPost`) para evitar `NullReferenceException`.

---

## 🌐 Navegação

- O navegador não interpreta arquivos `.cshtml` diretamente. O servidor processa e converte para `.html`.
- O prefixo `~/` aponta para a raiz da aplicação.
- Use **Partial Views** para reaproveitar componentes (pasta `Pages/Shared`).
- **Tag Helpers** fornecem recursos extras no HTML (necessário importar `Microsoft.AspNetCore.Mvc.TagHelpers`).

---

## 📦 Organização de Código

- **_ViewImports.cshtml**: centraliza `@using`, namespaces e Tag Helpers para todas as páginas.
- **_Layout.cshtml**: define a estrutura base para todas as páginas.
- **_ViewStart.cshtml**: configura o layout padrão.

**Exemplo de Layout:**

```razor
<!DOCTYPE html>
<html>
<head>
    <title>My Razor App</title>
</head>
<body>
    <header>
        <partial name="Shared/NavMenuPartial" />
    </header>
    <main>
        @RenderBody()
    </main>
    <footer></footer>
</body>
</html>
```

---

## 🚏 Rotas e Parâmetros

- Personalizar URL:
```razor
@page "~/Entrar"
```
- Evitar uso de `href` fixo, preferindo Tag Helpers:
```razor
<a asp-page="About">Sobre</a>
```
- Rotas com parâmetros opcionais:
```razor
@page "~/categorias/{skip?}/{take?}"
```

---

## 🎨 CSS e JavaScript

- CSS no `<head>` e JS antes de `</body>`.
- Use `asp-append-version="true"` para evitar problemas de cache após novas releases:
```razor
<link href="~/css/site.css" rel="stylesheet" asp-append-version="true" />
```
- Utilize um CSS global para estilos comuns e CSS específico para páginas individuais (*Nested CSS*).

---

## 🔗 Links Úteis

- [Documentação ASP.NET Core](https://learn.microsoft.com/aspnet/core)
- [Razor Pages Overview](https://learn.microsoft.com/aspnet/core/razor-pages)

---

✍️ *Essas anotações foram organizadas e padronizadas para servir como referência no desenvolvimento com Razor Pages.*
