using System.Linq;

namespace quidgest.uitests.pages;

public class AppPage: PageObject
{
	private IWebElement Container => driver.FindElement(By.ClassName("layout-container"));

	public IMenuControl Menu => new HorizontalMenuControl(driver, _menuTree);

	private By loginBtnLocator => By.Id("logon-menu-btn");
	private IWebElement loginBtn => driver.FindElement(loginBtnLocator);
	private By avatarLocator => By.Name("user-avatar");

	public AppPage(IWebDriver driver) : base(driver)
	{
		string url = Configuration.Instance.BaseUrl;
		driver.Navigate().GoToUrl(url);

		wait.Until(c => Container);
	}

	private void WaitForLoading()
	{
		wait.Until(c => Container.GetAttribute("data-loading") != "true");
	}

	public void ClickLogin()
	{
		WaitForLoading();
		loginBtn.Click();
	}

	public bool IsAuthenticated()
	{
		WaitForLoading();

		if (Container.FindElements(avatarLocator).Any())
			return true;

		return false;
	}

	//Header
		//logo
		//avatar
	//Menu
	//MainContent
		//breadcrumbs
		//sidebar
	//Footer
		//version

	private readonly static MenuTree _menuTree = DeclareMenuTree();

    private static MenuTree DeclareMenuTree()
    {
        MenuTree res = new MenuTree();
		string module;

		module = "PJF";
		res.AddModule(module);
		res.AddMenu(module, "1", null);
		res.AddMenu(module, "2", null);
		res.AddMenu(module, "21", "2");
		res.AddMenu(module, "22", "2");
		res.AddMenu(module, "23", "2");
		res.AddMenu(module, "24", "2");
		res.AddMenu(module, "25", "2");
		res.AddMenu(module, "3", null);
		res.AddMenu(module, "4", null);
		res.AddMenu(module, "5", null);
		res.AddMenu(module, "6", null);
		res.AddMenu(module, "61", "6");
		res.AddMenu(module, "62", "6");
		res.AddMenu(module, "63", "6");
		res.AddMenu(module, "7", null);
		res.AddMenu(module, "8", null);
        return res;
    }
}
