using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebShopAPI.Models.DTO
{
    public sealed record RequestToOrderDTO
    {
        public string? Phone { get; init; }
        [Required]
        public required string Email { get; init; }
        [Required]
        public required string DateTime { get; init; }
        [Required]
        public required decimal Summa { get; init; }
        [Required]
        public required IEnumerable<ProductInOrderDTO> Products { get; init; }
        public string? Message { get; init; }

        public string AsMessage() => string.Format(
            "Номер телефона: {1}{0}" +
            "Электронная почта: {2}{0}" +
            "Время заказа: {3}{0}" +
            "Сумма: {4}{0}" +
            "Товары: {0}{5}{0}" +
            "Сообщение: {0}{6}",
            Environment.NewLine,
            Phone,
            Email,
            DateTime,
            Summa,
            JsonConvert.SerializeObject(Products, Formatting.Indented),
            Message);
    }
}
