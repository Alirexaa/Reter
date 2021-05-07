using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reter.Application.Contracts.Blog.Comment;

namespace Reter.Presentation.MVCCore.Areas.Admin.Pages.Blog.CommentManagement
{
    public class ListModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;
        public List<CommentViewModel> Comments;
        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetComments();
        }

        public RedirectToPageResult OnPostConfirm(string id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostRemove(string id)
        {
            _commentApplication.Delete(id);
            return RedirectToPage("./List");

        }
    }
}
