using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Models;

namespace Users.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        public DocumentController(IAuthorizationService authorizationService)
        {
            this.authService = authorizationService;
        }

        IAuthorizationService authService;

        ProtectedDocument[] docs = new ProtectedDocument[]
        {
            new ProtectedDocument{Title = "Q3 Budget", Author="Alice", Editor="Joe"},
            new ProtectedDocument{Title = "Project Plan", Author = "Bob", Editor = "Alice"}
        };

        public IActionResult Index()
        {
            return View(docs);
        }

        public async Task<IActionResult> Edit(string title)
        {
            ProtectedDocument doc = docs.FirstOrDefault(d => d.Title == title);
            AuthorizationResult authResut = await authService.AuthorizeAsync(User, doc, "AuthorsAndEditors");
            if (authResut.Succeeded)
                return View(doc);
            else
                return new ChallengeResult(); //Сделает Logout
        }
    }
}