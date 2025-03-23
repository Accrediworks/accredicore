using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Accredi.Web.Public.Pages;

public class IndexModel : AccrediPublicPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
