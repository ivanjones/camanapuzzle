using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace CamanaBayPuzzle
{
   public class Home : BasePage
{
        public IWebElement cell0 => driver.FindElement(By.Id("cell0"));
        public IWebElement cell1 => driver.FindElement(By.Id("cell1"));
        public IWebElement cell2 => driver.FindElement(By.Id("cell2"));

        public IWebElement cell3 => driver.FindElement(By.Id("cell3"));
        public IWebElement cell4 => driver.FindElement(By.Id("cell4"));
        public IWebElement cell5 => driver.FindElement(By.Id("cell5"));

        public IWebElement cell6 => driver.FindElement(By.Id("cell6"));
        public IWebElement cell7 => driver.FindElement(By.Id("cell7"));
        public IWebElement cell8 => driver.FindElement(By.Id("cell8"));

        public IWebElement r0st => driver.FindElement(By.Id("R0ST"));
        public IWebElement r1st => driver.FindElement(By.Id("R1ST"));
        public IWebElement r2st => driver.FindElement(By.Id("R2ST"));

        public IWebElement c0st => driver.FindElement(By.Id("C0ST"));
        public IWebElement c1st => driver.FindElement(By.Id("C1ST"));
        public IWebElement c2st => driver.FindElement(By.Id("C2ST"));

    }
}
