using FormulaOne.Client.Services;
using FormulaOne.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace FormulaOne.Client.Pages;

public partial class RiderDetails
{
    protected string Message = string.Empty;

    protected Rider rider {get; set;} = new Rider();

    [Parameter]
    public string Id {get; set;}

    [Inject]
    private IRiderService riderService {get; set;}

    [Inject]
    private NavigationManager navigationManager {get; set;}

    protected async override Task OnInitializedAsync()
    {
        if(string.IsNullOrEmpty(Id))
        {
            //Adding a new rider

        }
        else
        {
            //Updating a new rider
            var riderId = Convert.ToInt32(Id);

            var apiRider = await riderService.GetRider(riderId);

            if(apiRider != null)
                rider = apiRider;

        }
    }

}