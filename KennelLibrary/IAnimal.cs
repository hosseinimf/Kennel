namespace KennelLibrary
{
    public interface IAnimal
    {
        int AnimalId { get; set; }
        string Name { get; set; }
        bool Status { get; set; }
        int OwnerId { get; set; }
        string OwnerName { get; set; }
        
    }
}