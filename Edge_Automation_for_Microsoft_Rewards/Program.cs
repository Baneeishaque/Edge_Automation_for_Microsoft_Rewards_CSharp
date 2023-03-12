//using OpenQA.Selenium;

using OpenQA.Selenium.Edge;

//using WebDriverManager;
//using WebDriverManager.DriverConfigs.Impl;

//var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

//Dictionary<String, String> edgeBrowsers = new() {
//    { "113.0.1732.0", Path.Combine(localAppData, @"Microsoft\Edge SxS\Application\msedge.exe") },
//    { "110.0.1587.69", @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe" }
//};

//foreach (var edgeBrowser in edgeBrowsers) {

//    new DriverManager().SetUpDriver(new EdgeConfig(), edgeBrowser.Key);

//    var edgeDriverOptions = new EdgeOptions {
//        BinaryLocation = edgeBrowser.Value,
//    };

//    edgeDriverOptions.AddArgument($"--profile-directory=Default");

//    var driver = new EdgeDriver(edgeDriverOptions);
//}

var driver = new EdgeDriver();

try {
    var i = 0;
    foreach (var line in File.ReadLines(path: "bing urls.txt")) {

        //Console.WriteLine(line);

        if (i==2) {
            break;
        }

        if (!String.IsNullOrWhiteSpace(line)) {

            driver.Url = line;

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(15000);
            if (i==0) {

                Thread.Sleep(7000);
            }
            else {
                Thread.Sleep(2000);
            }
        }
        i++;
    }
}
finally {

    driver.Quit();
}

//var element = driver.FindElement(By.Id("sb_form_q"));
//element.SendKeys("Rashmika Mandanna");
//element.Submit();

//element = driver.FindElement(By.LinkText("Movies"));
//element.Click();

//element = driver.FindElement(By.ClassName("items"));

//element = driver.FindElement(By.CssSelector("a[title='Navigate right']"));
//element.Click();

//var moviesElements = element.FindElements(By.CssSelector("li[class='item col']"));

//string[] movieLinks = Array.Empty<string>();

//foreach (var movieElement in moviesElements) {

//    Console.WriteLine(movieElement.Text);

//    var movieLink = movieElement.FindElement(By.ClassName("cardToggle"));
//    Console.WriteLine(movieLink.Text);

//    _ = movieLinks.Append(movieLink.GetAttribute("href"));
//}

//foreach (var movieLink in movieLinks) {

//    driver.Url = movieLink;

//    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
//}