namespace MyBlazorApp.Model.Entities;

public class RefreshTokenModel
{
    public long ID { get; set; }
    public long UserID { get; set; }
    public string RefreshToken { get; set; }

    #region Relations

    public virtual UserModel User { get; set; }

    #endregion
}
