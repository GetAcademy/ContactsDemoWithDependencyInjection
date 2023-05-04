using System.Text.Json;
using ContactsDemo.Model;using ContactsDemoWithDependencyInjection;

/*
1: Skrive om v�r funksjonalitet til Service-klasse som baserer seg 
   p� en underliggende tjeneste for � skrive til og lese fra fil 
   (via interface)
1b: manuelt hack - f� det til � virke som f�r
2: Introdusere Dependency Injection-motor - dummy-eksempel
    - AddTransient
    - AddScoped
    - AddSingleton
3: Skrive om koden til � bruke v�r Service klasse via DI-motor
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




