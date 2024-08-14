using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;

namespace RegisterLocationChangingHandler.Components.Pages;

public partial class Home : IDisposable
{
  [Inject] NavigationManager NavigationManager { get; init; } = default!;

  private IDisposable? _registration;

  protected override void OnAfterRender(bool firstRender)
  {
    if (firstRender)
    {
      _registration = NavigationManager.RegisterLocationChangingHandler(OnBeforeLocationChanging);
    }
  }

  private ValueTask OnBeforeLocationChanging(LocationChangingContext context)
  {
    //some code
    return ValueTask.CompletedTask;
  }

  public void Dispose()
  {
    _registration?.Dispose();
  }
}