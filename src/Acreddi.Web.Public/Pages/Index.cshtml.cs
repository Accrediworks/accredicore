using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Acreddi.Web.Public.Pages;

public class IndexModel : AcreddiPublicPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
