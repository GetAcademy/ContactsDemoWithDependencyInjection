using ContactsDemo.Model;
using ContactsDemoWithDependencyInjection;

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
//builder.Services.AddScoped<IService, MyService>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<IContactRepository, FileContactRepository>();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapGet("/contacts", (ContactService contactService) =>
{
    return contactService.Read();
});
app.MapPost("/contacts", (Contact contact, ContactService contactService) =>
{
    contactService.Create(contact);
});
app.MapDelete("/contacts/{id}", (string id, ContactService contactService) =>
{
   contactService.Delete(id);
});
app.MapPut("/contacts", (Contact contactFromFrontend, ContactService contactService) =>
{
    contactService.Update(contactFromFrontend);
});
app.Run();




