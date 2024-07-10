namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MateprofForm: PageObject
{
	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl MateName => new BaseInputControl(driver, formLocator, "#MATEPROFMATE_NAME____");
	/// <summary>
	/// Crew name
	/// </summary>
	public LookupControl CrewCrewname => new LookupControl(driver, formLocator, "container-MATEPROFCREW_CREWNAME");
	public SeeMorePage CrewCrewnameSeeMorePage => new SeeMorePage(driver, "MATEPROF", "CREW.CREWNAME");
	/// <summary>
	/// Airline
	/// </summary>
	public IWebElement AirlnName => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public MateprofForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver)
	{
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
		wait.Until(c => form.FindElement(ByData.Key("MATEPROF")).GetAttribute("data-loading") != "true");
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
