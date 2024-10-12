namespace MyBlazorApp.Model.Models;

public class BaseResponseModel<TData>
{
    public bool Success { get; set; }

    public string ErrorMessage { get; set; }

    public TData Data { get; set; }
}
