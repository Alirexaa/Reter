using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reter.Application.Contracts.User;
using Reter.Application.Contracts.User.Commands;

namespace Reter.Presentation.MVCCore.Pages.Login
{
    public class IndexModel : PageModel
    {

        private readonly IUserApplication _userApplication;


        public IndexModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public void OnGet()
        {
        }

        public ActionResult OnPost(LoginUserCommand command)
        {
            var loginResult = _userApplication.Login(command);
            if (!loginResult.IsLogged)
                return RedirectToPage("./Login");
            Response.Cookies.Append("userName", loginResult.UserViewModel.UserName);
            return LocalRedirect("/Admin/Blog/CommentManagement/List");
        }
    }
}
