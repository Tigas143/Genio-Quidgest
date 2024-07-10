namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AirlnForm: PageObject
{
	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl AirlnName => new BaseInputControl(driver, formLocator, "#AIRLN___AIRLNNAME____");
	/// <summary>
	/// City
	/// </summary>
	public LookupControl CityCity => new LookupControl(driver, formLocator, "container-AIRLN___CITY_CITY____");
	public SeeMorePage CityCitySeeMorePage => new SeeMorePage(driver, "AIRLN", "CITY.CITY");
	/// <summary>
	/// Airport
	/// </summary>
	public LookupControl AirhbName => new LookupControl(driver, formLocator, "container-AIRLN___AIRHBNAME____");
	public SeeMorePage AirhbNameSeeMorePage => new SeeMorePage(driver, "AIRLN", "AIRHB.NAME");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public AirlnForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver)
	{
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
		wait.Until(c => form.FindElement(ByData.Key("AIRLN")).GetAttribute("data-loading") != "true");
	}

	public void Save()
	{
		WaitForLoading();
		saveBtn.Click();
	}

	public void Cancel(bool force = false)
	{
		WaitForLoading();
		cancelBtn.Click();

		// Force the cancel and lose all changes
		if (force)
		{
			ConfirmationPopup confirmPopup = new(driver);
			confirmPopup.Confirm();
		}
	}
}
