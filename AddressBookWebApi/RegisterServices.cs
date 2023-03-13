using AddressBook.Domain.Implementation;
using AddressBook.Domain.Interfaces;
using AddressBook.Repository.EfCore;
using AddressBook.Repository.Interfaces;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace AddressBookWebApi
{
    public class RegisterServices : IPackage
    {
        void IPackage.RegisterServices(Container container)
        {
            container.Register<IContactServices, ContactServices>(Lifestyle.Scoped);
            container.Register<IContactDbContext, ContactsDbContextRepo>(Lifestyle.Scoped);
            //   container.Register<DapperDbContext>(Lifestyle.Scoped);LoginCredentialsRepo
            container.Register<ILoginCredentialsDbContext, LoginCredentialsRepo>(Lifestyle.Scoped);
            container.Register<IAuthorizationServices, AuthenticationServices>(Lifestyle.Scoped);
        }
    }
}
