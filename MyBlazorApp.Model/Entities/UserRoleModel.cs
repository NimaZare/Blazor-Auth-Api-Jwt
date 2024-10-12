namespace MyBlazorApp.Model.Entities;

public class UserRoleModel
{
    public int ID { get; set; }
    public long UserID { get; set; }
    public int RoleID { get; set; }

    #region Relations

    public virtual RoleModel Role { get; set; }
    public virtual UserModel User { get; set; }

    #endregion
}
