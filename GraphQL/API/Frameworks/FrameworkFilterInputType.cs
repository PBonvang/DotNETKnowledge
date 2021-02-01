using DataAccess.Entities;
using HotChocolate.Data.Filters;

namespace API.Frameworks
{
   public class FrameworkFilterInputType : FilterInputType<Framework>
   {
      protected override void Configure(IFilterInputTypeDescriptor<Framework> descriptor)
      {
            descriptor.Ignore(t => t.Id);
      }
   }
}