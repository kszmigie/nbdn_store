<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="c#" AutoEventWireup="true" Inherits="nothinbutdotnetstore.web.core.DefaultViewFor`1[[nothinbutdotnetstore.model.Product, nothinbutdotnetstore, Version=0.0.0.0]], nothinbutdotnetstore, Version=0.0.0.0" MasterPageFile="Store.master"%>
<%@ Import Namespace="nothinbutdotnetstore.model" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application" %>
<%@ Import Namespace="nothinbutdotnetstore.web.helpers" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
							
		<%=GenerateForm.For(model) %>					
							<table style="WIDTH: 456px; HEIGHT: 114px" width="456">
								<tr>
									<td class="ListHead" id="productName" runat="server">
										<asp:Label id="productIdLabel" runat="server" CssClass="tableHeader" Height="8px" Visible="True"><%=model.name%></asp:Label></td>
								</tr>
								<tr>
									<td>
										<table style="WIDTH: 448px; HEIGHT: 68px">
											<tr valign="top">
												<td>Price</td>
												<td id="priceLabel" runat="server"> <%=model.price%></td>
											</tr>											
											<tr valign="top">
												<td id="descriptionLabel" runat="server"><%=model.description%></td>
											</tr>
											<tr valign="top">
												<td id="Td1" align="right" colspan="2" runat="server">
													<%=GenerateSubmit.For(model).WithText( "Add to cart").WithAction( "addToCartButton").WithClass("NormalButton")%></td>
													
											</tr>
										</table>
									</td>
								</tr>
							</table>
         </form>
					</asp:Content>		