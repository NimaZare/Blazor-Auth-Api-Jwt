namespace MyBlazorApp.Model.Entities;

public class UserModel
{
    public long ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    #region Relations

    public virtual ICollection<UserRoleModel> UserRoles { get; set; } = [];

    #endregion
}
