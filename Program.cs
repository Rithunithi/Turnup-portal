using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing.Text;
using System.Threading;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();

driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");

IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

IWebElement loginbutton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginbutton.Click();

IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("User has logged in successfully");
}
else
{
    Console.WriteLine("User hasn't been logged in");
}


// Create a new Time record

// Navigate to Time & Material module
IWebElement administrationoption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
administrationoption.Click();

IWebElement timeAndMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
timeAndMaterial.Click();

// Click on create new button
IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
createNewButton.Click();
Thread.Sleep(4000);

// Select "Time" from typecode dropdown
IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
typeCodeDropdown.Click();
Thread.Sleep(4000);

IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
timeOption.Click();
Thread.Sleep(4000);

// Enter code into code textbox
IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
codeTextBox.SendKeys("code1234");
Thread.Sleep(4000);

// Enter description into description textbox
IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
descriptionTextBox.SendKeys("Firsttask2023");
Thread.Sleep(4000);

// Enter price into price per unit textbox
IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceTextbox.SendKeys("120");
Thread.Sleep(4000);


// Click save button
IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
saveButton.Click();
Thread.Sleep(4000); 

// Check if new record has been created succesfully
IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPageButton.Click();

IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

if (newCode.Text == "code1234")
{
    Console.WriteLine("New Record has been created successfully.");
}
else 
{
    Console.WriteLine("Record has not been created.");
}

//****************Edit an existing record****************************

IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
editButton.Click();
Thread.Sleep(4000);


IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
editDescriptionTextbox.Clear();
Thread.Sleep(4000);
editDescriptionTextbox.SendKeys("Firsttask2024");
Thread.Sleep(4000);
//IWebElement editPriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
//editPriceTextbox.Clear();
//Thread.Sleep(4000);
//Console.WriteLine(editPriceTextbox);
//editPriceTextbox.Clear();
//editPriceTextbox.SendKeys("200");
//Thread.Sleep(4000);


IWebElement editsaveButton = driver.FindElement(By.Id("SaveButton"));
editsaveButton.Click();

Thread.Sleep(4000);

Console.WriteLine("The record has been edited successfully");

IWebElement goToLastPageEditbutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
goToLastPageEditbutton.Click();
Thread.Sleep(4000);

//************Delete record*************************************

IWebElement clickDeletebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
//*[@id="tmsGrid"]/div[3]/table/tbody/tr/td[5]/a[2]
//*[@id="usersGrid"]/div[3]/table/tbody/tr[9]/td[3]/a[2]
Thread.Sleep(4000);
clickDeletebutton.Click();
Thread.Sleep(4000);

//string alertMessage = driver.SwitchTo().Alert().Text;
//Console.WriteLine(alertMessage);
//Thread.Sleep(4000);

driver.SwitchTo().Alert().Accept();
//driver.SwitchTo().Alert().Dismiss();
Thread.Sleep(4000);

Console.WriteLine("The record has been deleted successfully");

IWebElement goToLastPagedeletebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPagedeletebutton.Click();


