# Ideas to test & things to try
- Integration tests where the seed data is in the fixture or maybe even in the test
- Having DAL repositories that return an unmaterialized query. That way we have the abstraction and the query functionlities provided in Linq.
- GraphQL schema sticting
- Using OIDC in an API
- Creating a library that seeds based on the given/arrange part of a test

# Ideas for example projects
## Personal car sharing service
A service where you can specify a car and add users, now everytime you go for a ride in the car, you just specify the counter at the end of your trip. Then when it's time to tank up the car you just input the price and the system calculates the percentages each person needs to pay and what that percentage is of the total amount.

Keys:  
- OIDC
- Simple