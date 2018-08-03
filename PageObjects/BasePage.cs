using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace CamanaBayPuzzle
{
    public class BasePage
{

    public IWebDriver driver;

    public BasePage()
    {
        driver = new ChromeDriver();
    }

    public void GoToPage()
    {
        driver.Navigate().GoToUrl("file:///C:/Users/ivanj/source/repos/CamanaBayPuzzle/CamanaPuzzleUI.html");
    }


}
}
