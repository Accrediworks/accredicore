using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Acreddi.Web.Pages;

public class IndexModel : AcreddiPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
