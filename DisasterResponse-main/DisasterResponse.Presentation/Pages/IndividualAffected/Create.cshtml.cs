using DisasterResponse.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;

namespace DisasterResponse.Presentation.Pages.IndividualAffected

{
    //public class IndividualsAffectedModel : PageModel
    //{
    //    private readonly ISender _sender;
    //    public IndividualsAffectedModel(ISender sender) => _sender = sender;

    //    public async Task OnGetAll(int pageIndex, int pageSize)
    //        => ViewData["Result"] = await _sender.Send(new GetAllIndividualAffectedQuery(pageIndex, pageSize));

    //    public async Task OnGetById(Guid id)
    //        => ViewData["Result"] = await _sender.Send(new GetIndividualAffectedByIdQuery(id));

    //    public async Task<IActionResult> OnPostAdd(string name, DateTime birthDate, List<DamageCase> damageCases)
    //    {
    //        ViewData["Result"] = await _sender.Send(new AddIndividualAffectedCommand(name, birthDate, damageCases));
    //        return RedirectToPage();
    //    }

    //    public async Task<IActionResult> OnPostUpdate(Guid id, string name, DateTime birthDate)
    //    {
    //        ViewData["Result"] = await _sender.Send(new UpdateIndividualsAffectedCommand(id, name, birthDate));
    //        return RedirectToPage();
    //    }

    //    public async Task<IActionResult> OnPostDelete(Guid id)
    //    {
    //        await _sender.Send(new DeleteIndividualAffectedCommand());
    //        return RedirectToPage();
    //    }
    //}
    public class CreateModel : PageModel
    {

        public DisasterDbContext _db { get; set; }

        public CreateModel(DisasterDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Domain.Entities.IndividualAffected IndividualAffected { get; set; }
        public IActionResult OnGet()
        {

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
                _db.IndividualsAffected.Add(IndividualAffected);
                _db.SaveChanges();
                TempData["success"] = "Saved Successfully!";

            }
            catch (Exception ex)
            {
                TempData["error"] = "An error occured!";
            }
            return RedirectToPage();
        }
    }
}





