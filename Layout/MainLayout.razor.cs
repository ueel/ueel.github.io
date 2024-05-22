using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Yamine.Services;

namespace Yamine.Layout;

public partial class MainLayout
{
    [Inject]
    protected SecurityService Security { get; set; }

    bool sidebarExpanded = true;

    protected void ProfileMenuClick(RadzenProfileMenuItem args)
    {
        if (args.Value == "Logout")
        {
            Security.Logout();
        }
    }

}
