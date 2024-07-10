namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PassegerForm: PageObject
{
	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Personal info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, formLocator, "#PASSEGERPSEUDNEWGRP02-container");
	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl PersoName => new BaseInputControl(driver, formLocator, "#PASSEGERPERSONAME____");
	/// <summary>
	/// ID
	/// </summary>
	public DocumentControl PersoId => new DocumentControl(driver, formLocator, "container-PASSEGERPERSOID______");
	/// <summary>
	/// Nationality
	/// </summary>
	public BaseInputControl PersoNatio => new BaseInputControl(driver, formLocator, "#PASSEGERPERSONATIO___");
	/// <summary>
	/// Contact info
	/// </summary>
	public IWebElement PseudNewgrp01 => throw new NotImplementedException();
	/// <summary>
	/// Mobile contact
	/// </summary>
	public BaseInputControl PersoPhone => new BaseInputControl(driver, formLocator, "#PASSEGERPERSOPHONE___");
	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl PersoEmail => new BaseInputControl(driver, formLocator, "#PASSEGERPERSOEMAIL___");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public PassegerForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver)
	{
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
		wait.Until(c => form.FindElement(ByData.Key("PASSEGER")).GetAttribute("data-loading") != "true");
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
