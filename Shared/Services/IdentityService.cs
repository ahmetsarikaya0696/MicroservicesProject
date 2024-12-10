namespace Shared.Services
{
    public class IdentityService : IIdentityService
    {
        public Guid UserId => Guid.Parse("08dd187b-5cce-aa74-08bf-b88573810000");

        public string UserName => "RandomUsername";
    }
}
