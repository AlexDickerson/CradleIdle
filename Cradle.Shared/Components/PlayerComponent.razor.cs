using Cradle.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Shared.Components
{
    public partial class PlayerComponent(IPlayerView playerView) : ComponentBase
    {
        protected override void OnInitialized()
        {
            playerView.OnPlayerUpdated += PlayerUpdated;
        }

        public async Task PlayerUpdated()
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
    }
}
