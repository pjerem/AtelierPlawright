using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace AtelierPlawright
{
    public class LuccaEstPresentSurWikipedia
    {
        private IPage Page;
        private IBrowser Browser;
        

        [Test]
        public async Task LuccaShouldHaveTheRightPostalCode()
        {
            using var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync();
            Page = await Browser.NewPageAsync();
            
            // Open new page
            await Page.GotoAsync("https://www.wikipedia.org/");
            await Page.ClickAsync("text=Français");
            await Page.ClickAsync("[placeholder=\"Rechercher dans Wikipédia\"]");
            await Page.FillAsync("[placeholder=\"Rechercher dans Wikipédia\"]", "Lucca");
            await Page.PressAsync("[placeholder=\"Rechercher dans Wikipédia\"]", "Enter");
            await Page.ClickAsync("text=Lucques");

            var pageContent = await Page.ContentAsync();
            
            Assert.IsTrue(pageContent.Contains("55100"));
            
            await Browser.CloseAsync();
        }
        
        
    }
}