using caresoft_core.Models;

namespace caresoft_core.Dto;

public class CuentumDto
{
    public uint IdCuenta { get; set; }
    public decimal Balance { get; set; }
    public string Estado { get; set; }

    public static CuentumDto FromModel(Cuentum model)
    {
        return new CuentumDto
        {
            IdCuenta = model.IdCuenta,
            Balance = model.Balance,
            Estado = model.Estado
        };
    }
}