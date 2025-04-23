using System.Collections.Generic;
using Volo.Abp.Localization;

namespace Accredi.Web.Theme.Portal.Themes.Portal.Components.Toolbar.LanguageSwitch;

public class LanguageSwitchViewComponentModel
{
    public LanguageInfo CurrentLanguage { get; set; }

    public List<LanguageInfo> OtherLanguages { get; set; }
}
