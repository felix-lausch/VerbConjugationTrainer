using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VerbWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            this.logger = logger;
        }

        public List<string> Items { get; set; }

        public void OnGet()
        {
            Items = ["Item 1", "Item 2", "Item 3"];
        }

        public PartialViewResult OnGetMoreItems()
        {
            Items = ["Item 4", "Item 5", "Item 6"];
            return Partial("_ItemList", this);
        }

        public PartialViewResult OnGetClear()
        {
            Items = [];
            return Partial("_ItemList", this);
        }
    }
}