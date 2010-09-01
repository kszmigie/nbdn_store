<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
		<!-- for each of the main departments in the store -->
        	<% foreach (Department department in (IEnumerable<Department>)Items["ViewModel"])
            {%>
            <tr class="ListItem">
               		 <td>                     
                        <%= department.DepartmentName %>
                	</td>
           	 </tr>        
             <%
            }%>
	    </table>            
</asp:Content>
