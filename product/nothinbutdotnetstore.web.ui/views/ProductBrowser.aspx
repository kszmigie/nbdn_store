<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" AutoEventWireup="true" Inherits="nothinbutdotnetstore.web.core.DefaultViewFor`1[[System.Collections.Generic.IEnumerable`1[[nothinbutdotnetstore.model.Product, nothinbutdotnetstore, Version=0.0.0.0]], mscorlib, Version=3.5.0.0]], nothinbutdotnetstore, Version=0.0.0.0" MasterPageFile="Store.master" %>
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <form></form>
    <p id="noResultsParagraph" runat="server" visible="true">No Results Found</p>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Quantity</th>                   
                        <th>Price</th>                                                
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
    
		<!-- for each product in the department -->
		    <%
        	    foreach (var product in model)
             {%>
            <tr class="nonShadedRow">
               		 <td class="ListItem">                     
                        <a href="~/views/ProductDetail.aspx"><%=product.name%></a>
                        <br /><br />
                        <%= product.description %>
                        <br /><br />
                        <%= product.price %>
                	</td>
           	 </tr>        
             <%
             }%>    						
    	</table>	
								<table>
									<tr>
										<td>
											<asp:button id="addSelectedItemsToCartButton" runat="server" Text="Add Selected Items To Cart" CssClass="normalButton"
												Width="184px"></asp:button></td>
										<td>
											<asp:Button id="goToCartButton" runat="server" Text="Go To Shopping Cart" CssClass="normalButton"></asp:Button></td>
										<td>
											<asp:button id="checkoutButton" runat="server" Text="Continue to checkout" CssClass="normalButton"
												Width="184px"></asp:button></td>
									</tr>
								</table>							
								    
								
							
		</asp:Content>
