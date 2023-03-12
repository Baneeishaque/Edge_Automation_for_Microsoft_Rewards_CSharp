using OpenQA.Selenium.Edge;

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