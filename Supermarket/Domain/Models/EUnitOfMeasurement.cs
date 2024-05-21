using System.ComponentModel;

namespace Supermarket.Domain.Models
{
    /// <summary>
    /// Enum para possíveis unidades de medida de um produto
    /// </summary>
    public enum EUnitOfMeasurement : byte
    {
        [Description("UN")]
        Unity = 1,
        [Description("MG")]
        Miligram = 2,
        [Description("G")]
        Gram = 3,
        [Description("KG")]
        Kilogram = 4,
        [Description("L")]
        Liter = 5,
    }
}
