namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class BookingForm: PageObject
{
	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Booking number
	/// </summary>
	public BaseInputControl BookgBnum => new BaseInputControl(driver, formLocator, "#BOOKING_BOOKGBNUM____");
	/// <summary>
	/// Flight number identification
	/// </summary>
	public LookupControl FlighFlighnum => new LookupControl(driver, formLocator, "container-BOOKING_FLIGHFLIGHNUM");
	public SeeMorePage FlighFlighnumSeeMorePage => new SeeMorePage(driver, "BOOKING", "FLIGH.FLIGHNUM");
	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl BookgPrice => new BaseInputControl(driver, formLocator, "#BOOKING_BOOKGPRICE___");
	/// <summary>
	/// Passenger
	/// </summary>
	public LookupControl PersoName => new LookupControl(driver, formLocator, "container-BOOKING_PERSONAME____");
	public SeeMorePage PersoNameSeeMorePage => new SeeMorePage(driver, "BOOKING", "PERSO.NAME");
	/// <summary>
	/// Airline
	/// </summary>
	public IWebElement AirlnName => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public BookingForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver)
	{
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
		wait.Until(c => form.FindElement(ByData.Key("BOOKING")).GetAttribute("data-loading") != "true");
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
