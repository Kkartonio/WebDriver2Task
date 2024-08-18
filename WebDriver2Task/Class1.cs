using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Xml.Linq;
using FluentAssertions;

namespace WebDriver2
{
    public class WebDriver
    {
        [Test]
        public void GoogleSearch()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pastebin.com/");
            driver.Manage().Window.Maximize();

            IWebElement txtField = driver.FindElement(By.Name("PostForm[text]"));
            string expectedCode = "git config --global user.name  \"New Sheriff in Town\"\r\n" +
                                  "git reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\r\n" +
                                  "git push origin master --force\r\n";
            txtField.SendKeys(expectedCode);

            IWebElement txtFieldTitle = driver.FindElement(By.Name("PostForm[name]"));
            string expectedTitle = "how to gain dominance among developers";
            txtFieldTitle.SendKeys(expectedTitle);

            IWebElement txtPasteExpiration = driver.FindElement(By.XPath("//*[@id='select2-postform-expiration-container']"));
            txtPasteExpiration.Click();
            IWebElement option10Minutes = driver.FindElement(By.XPath("//li[contains(text(), '10 Minutes')]"));
            option10Minutes.Click();

            IWebElement txtHighlighting = driver.FindElement(By.XPath("//*[@id='select2-postform-format-container']"));
            txtHighlighting.Click();
            IWebElement txtHighlighting1 = driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input"));
            txtHighlighting1.SendKeys("Bash");
            txtHighlighting1.SendKeys(Keys.Enter);

            IWebElement btnCreate = driver.FindElement(By.XPath("//*[@id='w0']/div[5]/div[1]/div[10]/button"));
            btnCreate.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement newPageTitle = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/div[2]/div[3]/div[1]/h1"));
            string actualTitle = newPageTitle.Text;
            if (actualTitle == expectedTitle)
            {
                Console.WriteLine("Title matches.");
            }
            else
            {
                Console.WriteLine($"Title does not match. Expected: {expectedTitle}, Actual: {actualTitle}");
            }

            IWebElement newPageHighlighting = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/div[4]/div[1]/div[1]/a[1]"));
            string actualHighlighting = newPageHighlighting.Text;
            if (actualHighlighting == "Bash")
            {
                Console.WriteLine("Highlighting matches.");
            }
            else
            {
                Console.WriteLine($"Highlighting does not match. Expected: Bash, Actual: {actualHighlighting}");
            }

            IWebElement newPageText = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/div[4]/div[2]/ol"));
            string actualText = newPageText.Text;
            if (actualText == expectedCode.Trim())
            {
                Console.WriteLine("Code matches.");
            }
            else
            {
                Console.WriteLine($"Code does not match. Expected: {expectedCode.Trim()}, Actual: {actualText}");
            }
        }
    }
}
