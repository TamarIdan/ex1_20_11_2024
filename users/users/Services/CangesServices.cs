using users.Repositoreis;

namespace users.Services
{
    public class CangesServices:ICangesServices
    {
        private readonly IChangesRepositoreis _changesRepositoreis;

        public CangesServices(IChangesRepositoreis changesRepositoreis)
        {
            _changesRepositoreis = changesRepositoreis;
        }

        public void Add(Models.Change Achange)
        {
            _changesRepositoreis.Add(Achange);
        }
    }
}
