using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;

namespace MinimalWebApp;

public static class Routes
{
    private const string ContentType = "text/html; charset=utf-8";
    private static readonly Random random = new Random();
    private static readonly Person person = new Person("Joe", "Blow", "joe@blow.com");

    public static void MapRoutes(this WebApplication app)
    {
        app.MapGet("/", () =>
        {
            var html = File.ReadAllText(@"Html/index.html");

            var choices = Directory.EnumerateFiles("Text").Select(x => Path.GetFileNameWithoutExtension(x));
            var items = string.Join("\n", choices.Select(x => $"<li><a href=\"{x}\">{x}</a></li>"));

            html = html.Replace("{{items}}", items);

            return Results.Content(html, ContentType);
        });

        app.MapGet("/list", () =>
        {
            var html = @"<ul>{{innerList}}</ul>";

            var innerList = Enumerable
                .Range(1, random.Next(1, 7))
                .Select(i => $"<li>{i}</li>");

            html = html.Replace("{{innerList}}", string.Join("\n", innerList));

            return Results.Content(html, ContentType);
        });

        app.MapPost("/name", (HttpContext ctx) =>
        {
            var name = ctx.Request.Form["hello-input"];
            if (string.IsNullOrEmpty(name))
            {
                return Results.BadRequest();
            }

            return Results.Content($"<h1>Hello {name}!</h1>", ContentType);
        });

        app.MapGet("/contact/1", () =>
        {
            var html = $"<div hx-target=\"this\" hx-swap=\"outerHTML\"><div><label>First Name: </label>{person.FirstName}</div><div><label>Last Name: </label>{person.LastName}</div><div><label>Email: </label>{person.Email}</div><button hx-get=\"/contact/1/edit\" class=\"btn primary\">Click To Edit</button></div>";

            return Results.Content(html, ContentType);
        });

        app.MapGet("/contact/1/edit", () =>
        {
            var html = $"<form hx-put=\"/contact/1\" hx-target=\"this\" hx-swap=\"outerHTML\"><div><label>FirstName: </label><input type=\"text\" name=\"firstName\" value=\"{person.FirstName}\" /></div><div><label>LastName: </label><input type=\"text\" name=\"lastName\" value=\"{person.LastName}\" /></div><div><label>Email: </label><input type=\"email\" name=\"email\" value=\"{person.Email}\" /></div><br/><button style=\"color:dodgerblue\">Save</button><button style=\"color:orangered\" hx-get=\"/contact/1\">Cancel</button></form>";

            return Results.Content(html, ContentType);
        });

        app.MapPut("/contact/1", (HttpContext ctx) =>
        {
            var firstName = ctx.Request.Form["firstName"];
            var lastName = ctx.Request.Form["lastName"];
            var email = ctx.Request.Form["email"];

            var updatedPerson = new Person(firstName!, lastName!, email!);

            if (string.IsNullOrEmpty(updatedPerson.FirstName) || string.IsNullOrEmpty(updatedPerson.LastName) || string.IsNullOrEmpty(updatedPerson.Email))
            {
                return Results.BadRequest();
            }

            person.Update(updatedPerson.FirstName!, updatedPerson.LastName!, updatedPerson.Email!);

            var html = $"<div hx-target=\"this\" hx-swap=\"outerHTML\"><div><label>First Name</label>: {updatedPerson.FirstName}</div><div><label>Last Name: </label>{updatedPerson.LastName}</div><div><label>Email: </label>{updatedPerson.Email}</div><button hx-get=\"/contact/1/edit\" class=\"btn primary\">Click To Edit</button></div>";

            return Results.Content(html, ContentType);
        });
    }

    private sealed class Person(string firstName, string lastName, string email)
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;

        public void Update(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    };
}
