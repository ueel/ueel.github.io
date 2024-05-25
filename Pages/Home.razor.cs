using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Yamine.Services;

namespace Yamine.Pages
{
    public partial class Home
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }



        protected override async Task OnInitializedAsync()
        {

        }



        Stats monthlyStats { get; set; }
        IEnumerable<RevenueByCompany> revenueByCompany { get; set; }
        IEnumerable<RevenueByMonth> revenueByMonth { get; set; }
        IEnumerable<RevenueByEmployee> revenueByEmployee { get; set; }

        protected int getOpportunitiesResultCount;

        protected int getTasksResultCount;
    }

    public class Stats
    {
        public DateTime Month { get; set; }
        public decimal Revenue { get; set; }

        public int Opportunities { get; set; }
        public decimal AverageDealSize { get; set; }
        public double Ratio { get; set; }
    }

    public class RevenueByCompany
    {
        public string Company { get; set; }
        public decimal Revenue { get; set; }
    }

    public class RevenueByEmployee
    {
        public string Employee { get; set; }
        public decimal Revenue { get; set; }
    }

    public class RevenueByMonth
    {
        public DateTime Month { get; set; }
        public decimal Revenue { get; set; }
    }

}
