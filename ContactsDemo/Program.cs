using System.Text.Json;
using ContactsDemo.Model;using ContactsDemoWithDependencyInjection;

/*
1: Skrive om vår funksjonalitet til Service-klasse som baserer seg 
   på en underliggende tjeneste for å skrive til og lese fra fil 
   (via interface)
1b: manuelt hack - få det til å virke som før
2: Introdusere Dependency Injection-motor - dummy-eksempel
    - AddTransient
    - AddScoped
    - AddSingleton
3: Skrive om koden til å bruke vår Service klasse via DI-motor
4: SQL?

 */

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IService, MyService>();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();

var fileContactRepository = new FileContactRepository();
var contactService = new ContactService(fileContactRepository);

app.MapGet("/contacts", (IService service) =>
{
    service.DoSomething();
    return contactService.Read();
});
app.MapPost("/contacts", (Contact contact) =>
{
    contactService.Create(contact);
});
app.MapDelete("/contacts/{id}", (string id) =>
{
   contactService.Delete(id);
});
app.MapPut("/contacts", (Contact contactFromFrontend) =>
{
    contactService.Update(contactFromFrontend);
});
app.Run();




