namespace CK.Lum.Material.Api.Transport
{
    /// <summary>
    /// Transferobject which the user sends and receives
    /// </summary>
    public class MaterialDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public bool? IsVisible { get; set; }

        public string TypeOfPhase { get; set; }

        public MaterialFunctionDto MaterialFunction { get; set; }
    }
}
