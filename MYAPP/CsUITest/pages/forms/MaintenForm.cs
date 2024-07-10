namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MaintenForm: PageObject
{
	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Model
	/// </summary>
	public LookupControl PlaneModel => new LookupControl(driver, formLocator, "container-MAINTEN_PLANEMODEL___");
	public SeeMorePage PlaneModelSeeMorePage => new SeeMorePage(driver, "MAINTEN", "PLANE.MODEL");
	/// <summary>
	/// Maintanace Valid Untill
	/// </summary>
	public DateInputControl MaintDate => new DateInputControl(driver, formLocator, "#MAINTEN_MAINTDATE____");
	/// <summary>
	/// Status
	/// </summary>
	public EnumControl MaintStatus => new EnumControl(driver, formLocator, "container-MAINTEN_MAINTSTATUS__");
	/// <summary>
	/// Airline
	/// </summary>
	public IWebElement AirlnName => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public MaintenForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver)
	{
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
		wait.Until(c => form.FindElement(ByData.Key("MAINTEN")).GetAttribute("data-loading") != "true");
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
