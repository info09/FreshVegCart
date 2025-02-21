namespace FreshVegCart.Shared.Dto
{
    public record PlaceOrderDto(int UserAddressId, string Address, string AddressName, OrderItemSaveDto[] Items);
}
