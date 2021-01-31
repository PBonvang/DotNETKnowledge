# GraphQL
GraphQL is a pattern that seeks to solve the problems of conventional REST APIs.  
GraphQL summed up: *Lets clients query your API for data.*  
So what does that mean? Well when you think of REST over and under fetching might come to mind. And having to plan the paths/routes so that it makes sense and is forseeable for consumers.  
Well F that! With GraphQL consumers send a request to the API based on what the API supplies of models. The API then returns with exactly those properties nothing less nothing more.  
This means you won't have to send three requests to show one view, no sir, one GraphQL request and you're good to go.  
**Example:**  
Say we have the following models:  
Role {Id, Name}  
Permission {Id, Name}  
RolePermissions {RoleId, PermissionId}  

Now we wish to fetch a role with it's permissions including the permission name:  
REST:  
First we would call */roles/{id}* to get the role information, then */roles/{id}/permissions* to get the role permissions. So two requests. And if you wish to show a list of roles with their permissions just imagine having to call the */roles* endpoint and then the */roles/{id}/permissions* for each role. No thanks.  

GraphQL:  
In GraphQL there's only one endpoint, where you post your queries to. The query for the above mentioned scenario is, and this is just in the body of a json request:  
```
query {
    role(id: {id}) {
        name,
        permissions {
            name
        }
    }
}
```
And for the view will all roles with permissions:
```
query {
    roles {
        name,
        permissions {
            name
        }
    }
}
```

## .NET GraphQL Libraries
In choosing between libraries I ended up deciding to use Hot Chocolate, as it seems prettier, is faster and has the Vue vibe. Something new and trending trending with faster dev time... 

### GraphQL .NET
This is the first GraphQL library for .NET and is therefor the most liked and used.

### Hot chocolate
This is a newer library which is trending.

## Hot chocolate

### My experiences
- Accessing the Banana Cake Pop interface, schemas doesn't reload with the "Reload schema" button unfortunately. Maybe, it seems to have been fixed.

## Sources
- https://github.com/ChilliCream/hotchocolate/issues/392
- https://github.com/ChilliCream/graphql-workshop