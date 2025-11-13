# saucedemo-tests

<h3>Task description</h3>
Launch URL: https://www.saucedemo.com <br>
<b>UC-1</b> Test Login form with empty credentials: <br>
Type any credentials into "Username" and "Password" fields.<br>
Clear inputs.<br>
Hit the "Login" button.<br>
Check the error messages: "Username is required"<br>
<b>UC-2</b> Test Login form with credentials by passing Username: <br>
Type any credentials into "Username"<br>
Clear the password input.<br>
Hit the "Login" button.<br>
Check the error messages: "Password is required"<br>
<b>UC-2</b> Test Login form with credentials by passing Username & Passowrd<br>
Type credentials in username which are under Accepted username section<br>
Enter password as secret_sauce.<br>
Click on Login and validate the title "Swag Labs" in the dashboard.<br>
Provide parallel execution, add logging for tests and use Data Provider to parametrize these 3 conditions: UC-1, UC-2, UC-3.<br>
<b>Additional options</b><br>
Test Automation tool: Selenium WebDriver<br>
Browsers: Edge, FireFox;<br>
Locators: CSS;<br>
Test Runner: xUnit;<br>
[Optional] Patterns 1) Abstaract Factory 2) Adapter 3) Bridge;<br>
[Optional] Test Automation Approach: BDD;<br>
Assetrions: FluentAssertions;<br>
[Optional] Loggers: Log4Net <br>
