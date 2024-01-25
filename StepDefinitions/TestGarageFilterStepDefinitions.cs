using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace AutomationTask.StepDefinitions
{
    [Binding]
    public class TestGarageFilterStepDefinitions
    {
        private readonly IPage _page;

        public TestGarageFilterStepDefinitions(Hooks.Hooks hooks)
        {
            _page = hooks.Page;
        }

        [Given(@"A user is searching properties for sale in Dublin")]
        public async Task GivenAUserIsSearchingPropertiesForSaleInDublin()
        {
            await _page.GotoAsync("https://www.daft.ie/property-for-sale/dublin");
            if (await _page.GetByTestId("notice").IsVisibleAsync())
            {
                await _page.Locator("#didomi-notice-agree-button").ClickAsync();
            }

            
        }

        [Given(@"Has a list of properties displayed")]
        public async Task GivenHasAListOfPropertiesDisplayed()
        {
            (await _page.GetByTestId("card-wrapper").First.IsVisibleAsync()).Should().BeTrue(); //check if the results are returned

        }

        [When(@"The User clicks on Filters")]
        public async Task WhenTheUserClicksOnFilters()
        {
            await _page.GetByTestId("open-filters-modal").ClickAsync();
        }

        [When(@"Enters text (.*) in the keyword search filter")]
        public async Task WhenEntersTextGarageInTheKeywordSearchFilter(String Garage)
        {
            await _page.GetByTestId("terms-input-text").FillAsync(Garage);
        }

        [When(@"Clicks on show Results tab")]
        public async Task WhenClicksOnShowResultsTab()
        {
            await _page.GetByTestId("filters-modal-show-results-button").ClickAsync();
            await _page.Locator("span:has-text(\"1 Filter\")").IsVisibleAsync(); //to check if the filter is applied
            (await _page.GetByTestId("card-wrapper").First.IsVisibleAsync()).Should().BeTrue(); //check if results are returned
        }

        [When(@"Opens the first advert")]
        public async Task WhenOpensTheFirstAdvert()
        {
           Thread.Sleep(2000);
            await _page.Locator("xpath=//*[@id=\"__next\"]/main/div[3]/div[1]/ul/li[1]/a").ClickAsync();
        }

        [Then(@"The advert must contain the keyword Garage in it")]
        public async Task ThenTheAdvertMustContainTheKeywordGarageInIt()
        {
            Thread.Sleep(2000);
            var text = await _page.GetByText("DescriptionSale Type:").TextContentAsync();
            (text.ToLower().Contains("garage")).Should().BeTrue();
        }

        [Given(@"A user is on daft homepage")]
        public async Task GivenAUserIsOnDaftHomepage()
        {
            await _page.GotoAsync("https://www.daft.ie/");
            if (await _page.GetByTestId("notice").IsVisibleAsync())
            {
                await _page.Locator("#didomi-notice-agree-button").ClickAsync();
            }
        }

        [Given(@"The user clicks on Buy Option")]
        public async Task GivenTheUserClicksOnBuyOption()
        {
            await _page.GetByRole(AriaRole.Menuitem, new() { Name = "Buy" }).ClickAsync();
        }

        [Given(@"The user selects dublin from the dropdown")]
        public async Task GivenTheUserSelectsDublinFromTheDropdown()
        {
            await _page.GetByRole(AriaRole.Option, new() { Name = "Dublin", Exact = true }).Locator("span").First.ClickAsync();
        }

        [Then(@"A list of properties in Dublin are returned")]
        public async Task ThenAListOfPropertiesInDublinAreReturned()
        {
            await _page.WaitForURLAsync("https://www.daft.ie/property-for-sale/dublin-city");
            (_page.Url).Should().BeEquivalentTo("https://www.daft.ie/property-for-sale/dublin-city"); //validate if the selection is correct and properties are shown for dublin
            (await _page.GetByTestId("card-wrapper").First.IsVisibleAsync()).Should().BeTrue(); //check if the results are returned
        }


    }
}
