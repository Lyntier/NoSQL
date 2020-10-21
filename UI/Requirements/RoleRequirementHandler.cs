using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace NoSQL.UI.Requirements
{
    public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (context.User.FindFirst("Role").Value.Equals("ServiceDeskEmployee"))
            {
                context.Succeed(requirement);
            }
  
            return Task.CompletedTask;
        }
    }
}