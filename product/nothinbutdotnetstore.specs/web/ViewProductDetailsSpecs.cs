 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ViewProductDetailsSpecs
     {
         public abstract class concern : Observes<ApplicationCommand,
                                             ViewProductDetails>
         {
        
         }

         [Subject(typeof(ViewProductDetails))]
         public class when_processing_request : concern
         {
             private Establish c = () =>
                                       {
                                           request = an<Request>();
                                           catalog = the_dependency<CatalogBrowsingTasks>();
                                           renderer = the_dependency<Renderer>();

                                           product = new Product();
                                           product.id = 13;

                                           request.Stub(x => x.map<Product>()).Return(product);
                                           catalog.Stub(x => x.get_product_details(product.id)).Return(product);
                                       };
             private Because b = () =>
                                 sut.process(request);

             private It should_provide_details_to_rendeder = () => renderer.received(x=>x.render(product));
             private static Renderer renderer;
             private static Request request;
             private static CatalogBrowsingTasks catalog;
             private static Product product;
         }
     }
 }
