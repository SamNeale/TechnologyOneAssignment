Welcome to the readme for my TechnologyOne assignent!

This application has a backend built in .NET 8 (including an xUnit test project) and a prototype frontend built using Angular 18.

There were a few important assumptions I made that in a workplace I would clarify with a Product Owner, or equivalent.

  1. I opted not to include the word 'and' anywhere in the output text as there are various edge cases associated with this.
  2. I bound the input number to be strictly positive and less than 1 trillion.

To run my submission:
  1. Clone this repository
  2. Open the backend project in Visual Studio, install the neccesary nuget pacakges, build the project and run it!
  3. Open the frontend project in Visual Studio code and run the following command 'ng serve' in a terminal
  4. Naviagte to http://localhost:4200/
  5. Try out my solution!

If you have any issues with the frontend make sure you have installed:
  1. Node.js version 20.17.0
  2. Npm 10.8.2

Test Plan:

  A full test plan for my submission would include both functional and non-functional tests.

  Non-functional tests would include:
    1. User Acceptance Tests (UAT) to verify that the solution is easily used and not overly confusing for the user.
    2. Performant and not overly slow to return a result in a predetermined time frame.

  Functional tests would include:
    1. Frontend unit tests in Angular which for the purpose of this assignment have not been included.
    2. Backend unit tests to test the number conversion functionality covering:
        a. Cases where a number is only fractional e.g 0.11
        b. Cases where a number is a whole number and a fraction e.g 1.11
        c. Cases where large portions of the number are not to be outputted as text e.g. 42,000,000 - only outputs 42 million and does not include 42 million one hundred thousand, etc.
        d. Error cases where a value is input that is out of range
        e. Error cases where a value is input that is not a number


