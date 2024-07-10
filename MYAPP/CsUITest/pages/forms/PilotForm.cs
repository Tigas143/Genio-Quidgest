namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PilotForm: PageObject
{
	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl PilotName => new BaseInputControl(driver, formLocator, "#PILOT___PILOTNAME____");
	/// <summary>
	/// Airline
	/// </summary>
	public LookupControl AirlnName => new LookupControl(driver, formLocator, "container-PILOT___AIRLNNAME____");
	public SeeMorePage AirlnNameSeeMorePage => new SeeMorePage(driver, "PILOT", "AIRLN.NAME");
	/// <summary>
	/// License number
	/// </summary>
	public BaseInputControl PilotLicense => new BaseInputControl(driver, formLocator, "#PILOT___PILOTLICENSE_");
	/// <summary>
	/// Years of experience
	/// </summary>
	public BaseInputControl PilotExperien => new BaseInputControl(driver, formLocator, "#PILOT___PILOTEXPERIEN");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public PilotForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver)
	{
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
		wait.Until(c => form.FindElement(ByData.Key("PILOT")).GetAttribute("data-loading") != "true");
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
