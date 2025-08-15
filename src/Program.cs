var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); //Adiciona suporte a Razor Pages

var app = builder.Build();

app.UseHttpsRedirection(); //Utiliza HTTPS
app.UseStaticFiles(); //Utiliza arquivos estáticos (CSS/IMG/JS) através da pasta wwwroot

//Auxilia no mapeamento das páginas
app.UseRouting();
app.MapRazorPages();

app.Run();