# Welcome to the README.md for my TechnologyOne assignment!

This application has a backend built in .NET 8 (including an xUnit test project) and a prototype frontend built using Angular 18.

## Assumptions I made that in a workplace I would clarify with a Product Owner, or equivalent.

  1. The example provided outputted the word equivalent of a number including 'and' in various places e.g. 'one hundred and one'
     
     However, I opted not to include the word 'and' anywhere in the output text as there are various edge cases associated with this,
     and it was unclear where 'and' should be included and when it should be avoided. Rather than implementing something with unclear
     requirements I opted for a solution that for now avoids the problem, but would warrant team discussion to avoid gramtical errors.
    
  2. I bound the input number to be strictly positive and less than 1 trillion, as there needed to be some upper and lower bound on the
     input number. Again another thing to talk to the team or Product Owner about as to what the upper bound would be, and weather we should
     include negative numbers.

## My Algorithm

I saw to possible ways to solve this problem:
  1. Using arhtmatic on the input number and incrementally decreasing the number until it converges to zero.
  2. Converting the floating point number to a string, and then iterating over each character.

I ultimately decided to go with solution 2 for the following reasons:
  1. It seemed more adaptable in case we had to support negative numbers in the future as arthimatic would have to support addition and subtraction.
  2. Intuatively I thought it posed faster performance iterating over a string in O(n) time rather than using arithmatic.


The intuiton for either algorthm hinges on the fact that every 3 digits in a number changes its place value from counting 
hundreds to thousands to millions to billions, etc. So as we move through the hundreds, thousands, millions, etc. lets 
work out how many of those hundreds, thousands, millions, etc. we have by counting hundreds. In the case of counting cents,
we are just counting 2 digits so we are only counting and not quantifying it with hundreds, thousands, millions, etc.

Heres how my algorithm works:

  1. Convert the floating point number to a string - called strNumber
  2. Iterate over strNumber starting from the least significant bit (the cents).
       a. We are doing this in intervals of 3 digits (or 2 for the case of cents).
       b. for each interval of digits append its english name to a stack.
       c. when an interval is complete append the stack to the output, reset the stack, and start the next interval.

## To run my submission:
  1. Clone this repository
  2. Open the backend project in Visual Studio, install the neccesary nuget pacakges, build the project and run it!
  3. Open the frontend project in Visual Studio code and run the following command 'ng serve' in a terminal
  4. Naviagte to http://localhost:4200/
  5. Try out my solution!

## If you have any issues with the frontend make sure you have installed:
  1. Node.js version 20.17.0
  2. Npm 10.8.2

## Test Plan:

  A full test plan for my submission would include both functional and non-functional tests.

  Non-functional tests would include:
    1. User Acceptance Tests (UAT) to verify that the solution is easily used and not overly confusing for the user.
    2. Performant and not overly slow to return a result in a predetermined time frame.

  Functional tests would include:
  
  Frontend unit tests in Angular which for the purpose of this assignment have not been included.
  
  Backend unit tests to test the number conversion functionality covering:
  1. Cases where a number is only fractional e.g 0.11
  2. Cases where a number is a whole number and a fraction e.g 1.11
  3. Cases where large portions of the number are not to be outputted as text e.g. 42,000,000 - only outputs 42 million and does not include 42 million one hundred thousand, etc.
  4. Error cases where a value is input that is out of range
  5. Error cases where a value is input that is not a number


