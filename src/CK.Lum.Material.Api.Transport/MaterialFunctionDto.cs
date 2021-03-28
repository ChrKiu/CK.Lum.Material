namespace CK.Lum.Material.Api.Transport
{
    /// <summary>
    /// Transferobject which the user sends and receives
    /// </summary>
    public class MaterialFunctionDto
    {
        public int? MinTemperature { get; set; }

        public int? MaxTemperature { get; set; }
    }
}
