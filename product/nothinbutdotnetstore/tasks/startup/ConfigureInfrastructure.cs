using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureInfrastructure :StartupCommand
    {
        StartupServices resolvers;

        public ConfigureInfrastructure(StartupServices resolvers)
        {
            this.resolvers = resolvers;
        }

        public void run()
       {
            resolvers.register_dependency_factory<MapperRegistry>(() => new DefaultMapperRegistry(IOC.retrieve.an<Container>()));
            resolvers.register_dependency_factory<MappingGateway>(() => new DefaultMappingGateway(IOC.retrieve.an<MapperRegistry>()));
       } 
    }
}