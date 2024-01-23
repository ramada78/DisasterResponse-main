using DisasterResponse.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterResponse.Presentation.Pages.IndividualAffected
{
    public class DisplayAllModel : PageModel
    {
        private readonly DisasterDbContext _db;
        public DisplayAllModel(DisasterDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Domain.Entities.IndividualAffected> IndividualsAffected { get; set; }
        [BindProperty]
        public Domain.Entities.IndividualAffected IndividualAffected { get; set; }
        public IActionResult OnGet()
        {
            IndividualsAffected = _db.IndividualsAffected.ToList();
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var individualAffected = _db.IndividualsAffected.Find(id);
            if (individualAffected == null) return NotFound();
            try
            {
                
                _db.IndividualsAffected.Remove(IndividualAffected);
                _db.SaveChanges();
                TempData["success"] = "Deleted Successfully!";
                
            }
            catch (Exception ex)
            {
                TempData["error"] = "An error on deleting record!";
            }
            return RedirectToPage();
        }
    }
}
