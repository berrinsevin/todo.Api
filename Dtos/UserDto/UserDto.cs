namespace todo.Api.Dtos
{
    public class UserDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool IsLord { get; set; }
    }
}