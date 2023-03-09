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

    protected void HandleFailedRequest()
    {
        Message = "Something went wrong, form not submited.";
    }

    protected void GoToRiders()
    {
        navigationManager.NavigateTo("/Riders");
    }

    protected async Task DeleteRider()
    {
        if(!string.IsNullOrEmpty(Id))
        {
            var riderId = Convert.ToInt32(Id);
            var result = await riderService.Delete(riderId);

            if(result)
                navigationManager.NavigateTo("/Riders");
            else
                Message = "Something went wrong, driver not deleted :( )";
        }
    }

    protected async void HandleValidRequest()
    {
        if(string.IsNullOrEmpty(Id))
        {
            //Add driver
            var result = await riderService.AddRider(rider);

            if(result != null)
                navigationManager.NavigateTo("/Riders");
            else
                Message = "Something went wrong, driver not added :( )";

        }
        else
        {
            //Update Driver
            var result = await riderService.Update(rider);

            if (result)
                navigationManager.NavigateTo("/Riders");
            else
                Message = "Something went wrong, driver not updated :( )";

        }
    }

}