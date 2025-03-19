namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IVehicleRepository VehicleRepository { get; }
        Task Commit();
    }
}
