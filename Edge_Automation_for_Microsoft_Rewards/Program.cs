using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

var driver = new EdgeDriver();

Dictionary<string, string> users = new();

try {

    using (StreamReader reader = new("accounts.csv")) {

        while (!reader.EndOfStream) {

            string line = reader.ReadLine();
            string[] values = line.Split(',');

            users.Add(values[0], values[1]);
        }
    }

    showUser(driver);
    browseUrls(driver);

    foreach (var user in users) {

        handleUser(driver,
               user.Key,
               user.Value);
    }
}
finally {

    //driver.Quit();
}

static void browseUrls(EdgeDriver driver) {

    var i = 0;
    foreach (var line in File.ReadLines(path: "bing urls.txt")) {

        if (i==5) {
            break;
        }

        browseUrl(driver, line);

        i++;
    }
}

static void showUser(EdgeDriver driver) {

    try {
        driver.Navigate().GoToUrl("https://login.live.com/");
        Thread.Sleep(10000);
    }
    catch (Exception) {

        showUser(driver);
    }
}

static void handleUser(EdgeDriver driver, string userName, string passWord) {

    showUser(driver);
    driver.FindElement(By.CssSelector("img[alt='BK']")).Click();

    Thread.Sleep(3500);
    driver.FindElement(By.LinkText("Sign out")).Click();

    driver.Url = "https://login.live.com/";
    driver.FindElement(By.CssSelector("input[type='email']")).SendKeys(userName);
    driver.FindElement(By.CssSelector("input[type='submit']")).Click();

    Thread.Sleep(4500);

    //if (driver.FindElement(By.CssSelector("div[role='heading']")).Text!="Enter password") {

    //    driver.FindElement(By.LinkText("Other ways to sign in")).Click();

    //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
    //    driver.FindElement(By.Id("credentialList")).FindElements(By.ClassName("tile-container"))[1].Click();
    //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
    //}

    driver.FindElement(By.CssSelector("input[type='password']")).SendKeys(passWord);
    driver.FindElement(By.CssSelector("input[type='submit']")).Click();

    driver.FindElement(By.Id("KmsiCheckboxField")).Click();
    driver.FindElement(By.CssSelector("input[type='submit']")).Click();

    showUser(driver);
    browseUrls(driver);
}

static void browseUrl(EdgeDriver driver, string line) {

    try {
        driver.Navigate().GoToUrl(line);
        Thread.Sleep(2000);
    }
    catch (Exception) {

        browseUrl(driver, line); ;
    }
}