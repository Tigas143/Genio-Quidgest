namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FlightForm: PageObject
{
	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Flight info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp04 => new CollapsibleZoneControl(driver, formLocator, "#FLIGHT__PSEUDNEWGRP04-container");
	/// <summary>
	/// Flight number identification
	/// </summary>
	public BaseInputControl FlighFlighnum => new BaseInputControl(driver, formLocator, "#FLIGHT__FLIGHFLIGHNUM");
	/// <summary>
	/// Aircraft
	/// </summary>
	public LookupControl PlaneModel => new LookupControl(driver, formLocator, "container-FLIGHT__PLANEMODEL___");
	public SeeMorePage PlaneModelSeeMorePage => new SeeMorePage(driver, "FLIGHT", "PLANE.MODEL");
	/// <summary>
	/// Travel info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, formLocator, "#FLIGHT__PSEUDNEWGRP02-container");
	/// <summary>
	/// Route
	/// </summary>
	public LookupControl RouteName => new LookupControl(driver, formLocator, "container-FLIGHT__ROUTENAME____");
	public SeeMorePage RouteNameSeeMorePage => new SeeMorePage(driver, "FLIGHT", "ROUTE.NAME");
	/// <summary>
	/// Departure
	/// </summary>
	public DateInputControl FlighDepart => new DateInputControl(driver, formLocator, "#FLIGHT__FLIGHDEPART__", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Arrival
	/// </summary>
	public DateInputControl FlighArrival => new DateInputControl(driver, formLocator, "#FLIGHT__FLIGHARRIVAL_", "dd/MM/yyyy HH:mm");
	/// <summary>
	/// Duracao em horas
	/// </summary>
	public BaseInputControl FlighDuration => new BaseInputControl(driver, formLocator, "#FLIGHT__FLIGHDURATION");
	/// <summary>
	/// Source
	/// </summary>
	public BaseInputControl FlighNamesc => new BaseInputControl(driver, formLocator, "#FLIGHT__FLIGHNAMESC__");
	/// <summary>
	/// Staff
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, formLocator, "#FLIGHT__PSEUDNEWGRP01-container");
	/// <summary>
	/// Cabin Crew
	/// </summary>
	public LookupControl CrewCrewname => new LookupControl(driver, formLocator, "container-FLIGHT__CREW_CREWNAME");
	public SeeMorePage CrewCrewnameSeeMorePage => new SeeMorePage(driver, "FLIGHT", "CREW.CREWNAME");
	/// <summary>
	/// Pilot
	/// </summary>
	public LookupControl PilotName => new LookupControl(driver, formLocator, "container-FLIGHT__PILOTNAME____");
	public SeeMorePage PilotNameSeeMorePage => new SeeMorePage(driver, "FLIGHT", "PILOT.NAME");
	/// <summary>
	/// Airsc
	/// </summary>
	public IWebElement PlaneAirsc => throw new NotImplementedException();
	/// <summary>
	/// Airline
	/// </summary>
	public IWebElement AirlnName => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public FlightForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver)
	{
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
		wait.Until(c => form.FindElement(ByData.Key("FLIGHT")).GetAttribute("data-loading") != "true");
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
