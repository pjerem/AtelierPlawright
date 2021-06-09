using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace AtelierPlawright
{
    public class LuccaEstPresentSurWikipedia
    {
        private IPage _page;
        private IBrowser _browser;


        [Test]
        public async Task LuccaShouldHaveTheRightPostalCode()
        {
            using var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync();
            _page = await _browser.NewPageAsync();

            // Open new page
            await _page.GotoAsync("https://www.wikipedia.org/");
            await _page.ClickAsync("text=Français");
            await _page.ClickAsync("[placeholder=\"Rechercher dans Wikipédia\"]");
            await _page.FillAsync("[placeholder=\"Rechercher dans Wikipédia\"]", "Lucca");
            await _page.PressAsync("[placeholder=\"Rechercher dans Wikipédia\"]", "Enter");
            await _page.ClickAsync("text=Lucques");

            var pageContent = await _page.ContentAsync();

            Assert.IsTrue(pageContent.Contains("55100"));

            await _browser.CloseAsync();
        }
    }
}