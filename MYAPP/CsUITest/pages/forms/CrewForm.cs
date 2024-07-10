namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CrewForm: PageObject
{
	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Crew Name
	/// </summary>
	public BaseInputControl CrewCrewname => new BaseInputControl(driver, formLocator, "#CREW____CREW_CREWNAME");
	/// <summary>
	/// Number of Crewmates
	/// </summary>
	public BaseInputControl CrewCount => new BaseInputControl(driver, formLocator, "#CREW____CREW_COUNT___");
	/// <summary>
	/// Airline
	/// </summary>
	public LookupControl AirlnName => new LookupControl(driver, formLocator, "container-CREW____AIRLNNAME____");
	public SeeMorePage AirlnNameSeeMorePage => new SeeMorePage(driver, "CREW", "AIRLN.NAME");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public CrewForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver)
	{
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
		wait.Until(c => form.FindElement(ByData.Key("CREW")).GetAttribute("data-loading") != "true");
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
