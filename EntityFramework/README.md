# Entity framework

## Commands

### Database
Generate domain entities and models context from existing database (Database first):  
dotnet ef dbcontext scaffold "CONNECTION_STRING" DATABASE_PROVIDER -o OUTPUT_DIR

## My findings

### SQLite and case in sensitive search
It has proven to be a much harder task than initially anticipated to do a simple contains search with the collation being NOCASE.  
I've tried:  
- Adding the collation as the column type - *.HasColumnType("TEXT COLLATE NOCASE");*  
- Adding the collation with the *UseCollation()* function both on the columns and the database it self.  

**Solution:**  
In the DBContext, add the following lines:  
```
modelBuilder.UseCollation("NOCASE");
modelBuilder.Entity<YourEntity>().Property(x => x.YourProperty).UseCollation("NOCASE");
```
And use the EF Like function in your queries:  
```
query.Where(c => EF.Functions.Like(c.YourPropery, $"%{request.YourPropertyQuery}%"));
```