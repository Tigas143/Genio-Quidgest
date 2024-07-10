namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RoutesForm: PageObject
{
	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl RouteName => new BaseInputControl(driver, formLocator, "#ROUTES__ROUTENAME____");
	/// <summary>
	/// Airline
	/// </summary>
	public LookupControl AirlnName => new LookupControl(driver, formLocator, "container-ROUTES__AIRLNNAME____");
	public SeeMorePage AirlnNameSeeMorePage => new SeeMorePage(driver, "ROUTES", "AIRLN.NAME");
	/// <summary>
	/// Source Airport
	/// </summary>
	public LookupControl AirscName => new LookupControl(driver, formLocator, "container-ROUTES__AIRSCNAME____");
	public SeeMorePage AirscNameSeeMorePage => new SeeMorePage(driver, "ROUTES", "AIRSC.NAME");
	/// <summary>
	/// Destination Airport
	/// </summary>
	public LookupControl AirdsName => new LookupControl(driver, formLocator, "container-ROUTES__AIRDSNAME____");
	public SeeMorePage AirdsNameSeeMorePage => new SeeMorePage(driver, "ROUTES", "AIRDS.NAME");
	/// <summary>
	/// Estimated duration
	/// </summary>
	public BaseInputControl RouteDuration => new BaseInputControl(driver, formLocator, "#ROUTES__ROUTEDURATION");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public RoutesForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver)
	{
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
		wait.Until(c => form.FindElement(ByData.Key("ROUTES")).GetAttribute("data-loading") != "true");
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
