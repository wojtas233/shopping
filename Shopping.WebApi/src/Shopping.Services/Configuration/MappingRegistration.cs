using Shopping.Services.Models;
using ExpressMapper;
using Shopping.DataAccess.Entities;

namespace Shopping.Services.Configuration
{
    public class MapperConfiguration
    {
        public void MappingRegistration()
        {
            Mapper.Register<TestModelA, TestModelB>();
            Mapper.Register<ClientModel, Client>();
            Mapper.Register<Client, ClientModel>();
        }
    }
}
