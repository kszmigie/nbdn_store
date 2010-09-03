 using System;
 using System.Collections.Generic;
 using System.Data;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers.basic;
 using nothinbutdotnetstore.tasks.startup;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class ResolverRegistrySpecs
     {
         public abstract class concern : Observes<ResolverRegistry,
                                             DefaultResolverRegistry>
         {
        
         }

         [Subject(typeof(DefaultResolverRegistry))]
         public class when_asked_for_a_resolver_for_a_known_type : concern
         {
             Establish c = () =>
                 {
                     resolver_for_type = an<DependencyResolver>();

                     resolvers = the_dependency<StartupServices>();

                     resolvers.Stub(r => r.get_resolver_for(typeof (IDbConnection))).Return(resolver_for_type);
                 };

             Because b = () =>
                result = sut.get_resolver_to_create(typeof (IDbConnection));

             It should_return_the_corresponding_resolver = () =>
                 result.ShouldEqual(resolver_for_type);

             static DependencyResolver result;
             static DependencyResolver resolver_for_type;
             static StartupServices resolvers;
         }
     }

 }
