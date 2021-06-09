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
            await InitBrowser();

            // Open new page
            await _page.GotoAsync("https://www.wikipedia.org/");
            await _page.ClickAsync("text=Français");
            await _page.ClickAsync("[placeholder=\"Rechercher dans Wikipédia\"]");
            await _page.FillAsync("[placeholder=\"Rechercher dans Wikipédia\"]", "Lucca");
            await _page.PressAsync("[placeholder=\"Rechercher dans Wikipédia\"]", "Enter");
            await _page.ClickAsync("text=Lucques");

            var pageContent = await _page.ContentAsync();

            Assert.IsTrue(pageContent.Contains("55100"));

            await CloseBrowser();
        }

        private async Task InitBrowser()
        {
            // J'aurai préféré passer par SetUp et TearDown mais impossible
            // d'écrire des methodes de SetUP et TearDown qui soient asynchrones.
            // Ce setup n'est pas l'idéal et je suis ouvert à mieux.
            using var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync();
            _page = await _browser.NewPageAsync();
        }
        
        private async Task CloseBrowser()
                 {
                     await _browser.CloseAsync();
                 }

    }
}