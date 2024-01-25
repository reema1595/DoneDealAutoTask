using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTask.Hooks
{
    [Binding]
    public class Hooks
    {
        public IPage Page { get; private set; } = null!;
        [BeforeScenario]
        public async Task OpenANewBrowser()
        {
            //Initialise Playwright
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // -> change to false if require headless mode
            });
            var context1 = await browser.NewContextAsync(); //Setup a browser context
            Page = await context1.NewPageAsync();//Initialise a page on the browser context.
        }

        [AfterScenario]
        public async Task CloseBrowserAfter()
        {
           await Page.CloseAsync();
        }
    }

}
