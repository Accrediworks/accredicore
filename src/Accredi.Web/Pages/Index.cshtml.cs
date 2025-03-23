using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Accredi.Web.Pages;

public class IndexModel : AccrediPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
