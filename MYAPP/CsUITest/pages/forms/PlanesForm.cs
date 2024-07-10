namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PlanesForm: PageObject
{
	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Identification
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, formLocator, "#PLANES__PSEUDNEWGRP02-container");
	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PlanePhoto => new BaseInputControl(driver, formLocator, "#PLANES__PLANEPHOTO___");
	/// <summary>
	/// Model
	/// </summary>
	public BaseInputControl PlaneId => new BaseInputControl(driver, formLocator, "#PLANES__PLANEID______");
	/// <summary>
	/// ID
	/// </summary>
	public BaseInputControl PlaneModel => new BaseInputControl(driver, formLocator, "#PLANES__PLANEMODEL___");
	/// <summary>
	/// Airline
	/// </summary>
	public LookupControl AirlnName => new LookupControl(driver, formLocator, "container-PLANES__AIRLNNAME____");
	public SeeMorePage AirlnNameSeeMorePage => new SeeMorePage(driver, "PLANES", "AIRLN.NAME");
	/// <summary>
	/// Technical specs
	/// </summary>
	public IWebElement PseudNewgrp01 => throw new NotImplementedException();
	/// <summary>
	/// Number of engines
	/// </summary>
	public BaseInputControl PlaneEngines => new BaseInputControl(driver, formLocator, "#PLANES__PLANEENGINES_");
	/// <summary>
	/// Manufacturer
	/// </summary>
	public BaseInputControl PlaneManufact => new BaseInputControl(driver, formLocator, "#PLANES__PLANEMANUFACT");
	/// <summary>
	/// Capacity
	/// </summary>
	public BaseInputControl PlaneCapacity => new BaseInputControl(driver, formLocator, "#PLANES__PLANECAPACITY");
	/// <summary>
	/// Date of manufacture
	/// </summary>
	public DateInputControl PlaneYear => new DateInputControl(driver, formLocator, "#PLANES__PLANEYEAR____");
	/// <summary>
	/// Age
	/// </summary>
	public BaseInputControl PlaneAge => new BaseInputControl(driver, formLocator, "#PLANES__PLANEAGE_____");
	/// <summary>
	/// Location and status
	/// </summary>
	public IWebElement PseudNewgrp03 => throw new NotImplementedException();
	/// <summary>
	/// Current Airport
	/// </summary>
	public LookupControl AircrName => new LookupControl(driver, formLocator, "container-PLANES__AIRCRNAME____");
	public SeeMorePage AircrNameSeeMorePage => new SeeMorePage(driver, "PLANES", "AIRCR.NAME");
	/// <summary>
	/// Status
	/// </summary>
	public EnumControl PlaneStatus => new EnumControl(driver, formLocator, "container-PLANES__PLANESTATUS__");
	/// <summary>
	/// Status of maintenance
	/// </summary>
	public BaseInputControl PlaneMaint => new BaseInputControl(driver, formLocator, "#PLANES__PLANEMAINT___");
	/// <summary>
	/// 
	/// </summary>
	public CheckboxInputControl PlaneIsmaint => new CheckboxInputControl(driver, formLocator, "#container-PLANES__PLANEISMAINT_");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public PlanesForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver)
	{
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
		wait.Until(c => form.FindElement(ByData.Key("PLANES")).GetAttribute("data-loading") != "true");
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
