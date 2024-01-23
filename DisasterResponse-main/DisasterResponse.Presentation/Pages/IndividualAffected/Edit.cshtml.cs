using DisasterResponse.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterResponse.Presentation.Pages.IndividualAffected
{
    public class EditModel : PageModel
    {
        public DisasterDbContext _db { get; set; }

        public EditModel(DisasterDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Domain.Entities.IndividualAffected IndividualAffected { get; set; }
        public IActionResult OnGet(Guid id)
        {
            var individualAffected = _db.IndividualsAffected.Find(id);
            if(individualAffected == null) return NotFound();
            IndividualAffected = individualAffected;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                if (IndividualAffected == null) { return NotFound(); }
                _db.IndividualsAffected.Update(IndividualAffected);
                _db.SaveChanges();
                TempData["success"] = "Saved Successfully!";
                return RedirectToPage("DisplayAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = "An error occured!";
            }
            return Page();
        }
    }
}
