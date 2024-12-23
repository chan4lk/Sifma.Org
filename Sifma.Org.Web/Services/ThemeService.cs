using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;

namespace Sifma.Org.Web.Services
{
    public interface IThemeService
    {
        bool IsDarkModeEnabled();
    }

    public class ThemeService : IThemeService
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public ThemeService(IUmbracoContextAccessor umbracoContextAccessor)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public bool IsDarkModeEnabled()
        {
            if (_umbracoContextAccessor.TryGetUmbracoContext(out var context))
            {
                var siteSettings = context.Content.GetAtRoot()
                    .FirstOrDefault(x => x.ContentType.Alias == "siteSettings");
                
                if (siteSettings != null)
                {
                    return siteSettings.Value<bool>("enableDarkMode");
                }
            }
            return false;
        }
    }
}
