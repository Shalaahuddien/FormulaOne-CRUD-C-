using FormulaOne.Client.Services;
using FormulaOne.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace FormulaOne.Client.Pages;

public partial class Riders
{
    [Inject]

    private IRiderService riderService {get; set;}

    public IEnumerable<Rider>_riders {get; set;} = new List<Rider>();

    protected async override Task OnInitializedAsync()
    {
        var apiRiders = await riderService.All();

        if(apiRiders != null &&  apiRiders.Any() )
            _riders = apiRiders;

    }

}