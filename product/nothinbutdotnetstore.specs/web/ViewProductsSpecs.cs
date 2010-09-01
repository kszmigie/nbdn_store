 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ViewProductsSpecs
     {
         public abstract class concern : Observes<ApplicationCommand,
                                             ViewProductCommand>
         {
        
         }

         [Subject(typeof(ViewProductsSpecs))]
         public class when_processing_request : concern
         {
             private Establish c = () =>
                                       {
                                           renderer = the_dependency<Renderer>();
                                           default_catalog_browsing_tasks = the_dependency<CatalogBrowsingTasks>();
                                           request = an<Request>();

                                           all_dept_products = new List<Product>();
                                           department = new Department();

                                           request.Stub(x => x.map<Department>()).Return(department);
                                           default_catalog_browsing_tasks.Stub(x => x.get_dept_products(department)).Return(all_dept_products);
                                       };

             Because b = () => sut.process(request);

             It should_tell_the_renderer_to_render_the_products = () => 
                 renderer.received(x => x.render(all_dept_products));
             
             static IEnumerable<Product> all_dept_products;
             private static Request request;
             private static CatalogBrowsingTasks default_catalog_browsing_tasks;
             private static Department department;
             private static Renderer renderer;
         }
     }
 }
