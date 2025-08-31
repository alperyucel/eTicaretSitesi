using Microsoft.AspNetCore.SignalR;

namespace AlisverisLab.MVC.Hubs
{
    public class SiteViewHub : Hub
    {
        static int siteViewCount;

        public override Task OnConnectedAsync()
        {
            siteViewCount++;
            SiteViewCountUpdate(siteViewCount);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            siteViewCount--;
            SiteViewCountUpdate(siteViewCount);
            return base.OnDisconnectedAsync(exception);
        }

        void SiteViewCountUpdate(int count)
        {
            Clients.All.SendAsync("viwerCountChanged", count).Wait();
        }
    }
}
