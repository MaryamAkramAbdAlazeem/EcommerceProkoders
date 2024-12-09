using EcommerceProkoders.DTOs.Order;
using System.Text.Json;

public class CartSessionHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CreateUpdateOrderHeader GetCart()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var cartJson = session.GetString("ShoppingCart");
        return string.IsNullOrEmpty(cartJson)
            ? new CreateUpdateOrderHeader()
            : JsonSerializer.Deserialize<CreateUpdateOrderHeader>(cartJson);
    }

    public void SaveCart(CreateUpdateOrderHeader cart)
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var cartJson = JsonSerializer.Serialize(cart);
        session.SetString("ShoppingCart", cartJson);
    }

    public void ClearCart()
    {
        _httpContextAccessor.HttpContext.Session.Remove("ShoppingCart");
    }
}
